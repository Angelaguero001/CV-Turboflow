

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.Serialization;



namespace logic
{
    public class BasePage : Page
    {
        public static string _Conexion;
        private const string SessionTime = "SessionTime";
        private const string SessionState = "SessionState";
        private const string UidPage = "UidPage";
        public const string REMOTE_HOST = "REMOTE_HOST";
        private const string sessionCurrentModuloID = "sessionCurrentModuloID";
        private const string sessionDTpermisos = "DTpermisos";
        private const string sessionMenuPermisosItems = "sessionMenuPermisosItems";
        private const string sessionPermisosPantalla = "PermisosPantalla";

        private int permisoid;

        public static string ConexionDB
        {
            get
            {
                if (BasePage._Conexion == null)
                    BasePage._Conexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
                return BasePage._Conexion;
            }
        }


        public int CurrentModuloID
        {
            get => HttpContext.Current.Session["sessionCurrentModuloID"] != null ? Convert.ToInt32(HttpContext.Current.Session["sessionCurrentModuloID"]) : 0;
            internal set => HttpContext.Current.Session["sessionCurrentModuloID"] = (object)value;
        }

        public string SqlLanguage => this.Session["SESSION_CULTURE"] is CultureInfo cultureInfo ? cultureInfo.TwoLetterISOLanguageName : "es";

        public string NombrePcMod
        {
            get
            {
                if (!(this.Session[nameof(NombrePcMod)] is string nombrePc))
                {
                    nombrePc = this.GetNombrePC();
                    this.Session[nameof(NombrePcMod)] = (object)nombrePc;
                }
                return nombrePc;
            }
        }

        protected string TypeName
        {
            get
            {
                string name = this.GetType().Name;
                return !name.StartsWith("pages_") ? string.Format("pages_{0}_aspx", (object)name) : name;
            }
        }



        public void RunJavascript(string script)
        {
            Page currentHandler = (Page)HttpContext.Current.CurrentHandler;
            ScriptManager.RegisterStartupScript(currentHandler, currentHandler.GetType(), Guid.NewGuid().ToString(), script, true);
        }

        public void RunJavascriptBeforeLoadPage(string script) => ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), script, true);

        public string GetAppSetting(string key) => WebConfigurationManager.AppSettings[key];

        public object GetSession(string name) => this.Session[name];


        public string GetNombrePC()
        {
            string empty = string.Empty;
            string ipString;
            try
            {
                ipString = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
            }
            catch
            {
                ipString = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
            }
            if (string.IsNullOrWhiteSpace(ipString))
            {
                ipString = Environment.MachineName;
            }
            else
            {
                IPAddress address = (IPAddress)null;
                if (!IPAddress.TryParse(ipString, out address))
                    ipString = ipString.Split('.')[0];
            }
            return ipString;
        }

        public static Decimal? DecimalIsNull(string numero) => numero == "" ? new Decimal?() : new Decimal?(Decimal.Parse(numero));

        public static string ToString(object value) => value is DBNull ? string.Empty : Convert.ToString(value);

        public static int ToInt32(object value) => value is DBNull ? 0 : Convert.ToInt32(value);

        public static Decimal ToDecimal(object value) => value is DBNull ? 0M : Convert.ToDecimal(value);

        public static bool ToBoolean(object value) => !(value is DBNull) && Convert.ToBoolean(value);

        public static DateTime ToDateTime(object value) => value is DBNull ? DateTime.MinValue : Convert.ToDateTime(value);

        public List<Dictionary<string, object>> DataTableToMap(System.Data.DataTable p_dt)
        {
            List<Dictionary<string, object>> map = new List<Dictionary<string, object>>();
            foreach (DataRow row in (InternalDataCollectionBase)p_dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn column in (InternalDataCollectionBase)p_dt.Columns)
                    dictionary.Add(column.ColumnName, row[column]);
                map.Add(dictionary);
            }
            return map;
        }

        public Dictionary<string, object> DataTableToDiccionary(System.Data.DataTable p_dt)
        {
            Dictionary<string, object> diccionary = (Dictionary<string, object>)null;
            foreach (DataRow row in (InternalDataCollectionBase)p_dt.Rows)
            {
                diccionary = new Dictionary<string, object>();
                foreach (DataColumn column in (InternalDataCollectionBase)p_dt.Columns)
                    diccionary.Add(column.ColumnName, row[column]);
            }
            return diccionary;
        }

        public static System.Data.DataTable GetDataTableFromDictionaries<T>(
          List<Dictionary<string, T>> list)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            if (list == null || !list.Any<Dictionary<string, T>>())
                return dataTable;
            foreach (DataColumn column in list.First<Dictionary<string, T>>().Select<KeyValuePair<string, T>, DataColumn>((Func<KeyValuePair<string, T>, DataColumn>)(c => new DataColumn(c.Key, typeof(T)))))
                dataTable.Columns.Add(column);
            foreach (DataRow row in list.Select<Dictionary<string, T>, DataRow>((Func<Dictionary<string, T>, DataRow>)(r =>
            {
                DataRow dataRow = dataTable.NewRow();
                r.ToList<KeyValuePair<string, T>>().ForEach((Action<KeyValuePair<string, T>>)(c => dataRow.SetField<T>(c.Key, c.Value)));
                return dataRow;
            })))
                dataTable.Rows.Add(row);
            return dataTable;
        }

        public Dictionary<string, object> Info(System.Data.DataTable dtInfo) => new Dictionary<string, object>();

        public string Serialize(Dictionary<string, object> a) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Serialize((object)a);

        public string SerializerJson(List<Dictionary<string, object>> a) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Serialize((object)a);

        public string SerializerJsonString(Dictionary<string, string> a) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Serialize((object)a);

        public string SerializerJsonStringList(List<Dictionary<string, string>> a) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Serialize((object)a);

        public string SerializerJson(string a) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Serialize((object)a);

        public List<Dictionary<string, string>> Deserialize(string json) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Deserialize<List<Dictionary<string, string>>>(json);

        public Dictionary<string, string> DeserializeData(string json) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Deserialize<Dictionary<string, string>>(json);

        public Dictionary<string, object> DeserializeObj(string json) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Deserialize<Dictionary<string, object>>(json);

        public List<Dictionary<string, object>> DeserializeDataObj(string json) => new JavaScriptSerializer()
        {
            MaxJsonLength = int.MaxValue
        }.Deserialize<List<Dictionary<string, object>>>(json);

        public void InsertDetail(
          logic_acces a,
          string llave,
          string deserializeJson,
          string store,
          string valorLlave)
        {
            List<Dictionary<string, string>> dictionaryList1 = new List<Dictionary<string, string>>();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            List<Dictionary<string, string>> dictionaryList2 = this.Deserialize(deserializeJson);
            for (int index = 0; index < dictionaryList2.Count; ++index)
            {
                Dictionary<string, string> parameters = dictionaryList2[index];
                parameters[llave] = valorLlave;
                a.ExecuteNonQuery(store, parameters);
            }
        }

        public void InsertDetailSimple(
          logic_acces a,
          string llave,
          string deserializeJson,
          string store,
          string valorLlave)
        {
            List<Dictionary<string, string>> dictionaryList1 = new List<Dictionary<string, string>>();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            List<Dictionary<string, string>> dictionaryList2 = this.Deserialize(deserializeJson);
            for (int index = 0; index < dictionaryList2.Count; ++index)
            {
                Dictionary<string, string> parameters = dictionaryList2[index];
                parameters[llave] = valorLlave;
                a.ExecuteNonQuerySimple(store, parameters);
            }
        }

        public void LogError(
            string Module,
            string FunctionName,
            string  LoggedUser,
            string InnerMessage,
            string ShortMessage 
            )
        {
            Dictionary<string, string> datos = new Dictionary<string, string>();

            datos["Module"]  = Module;
            datos["FunctionName"] = FunctionName;
            datos["LoggedUser"] = LoggedUser;
            datos["InnerMessage"] = InnerMessage;
            datos["ShortMessage"] = ShortMessage;

            logic_acces logicAcces = new logic_acces(BasePage.ConexionDB, false);

            DataSet ds = logicAcces.ExecuteQuery("LogError_Ins", datos);


        }

        public bool SendMail(
          string[] pMails,
          string pSubject,
          string pBody,
          bool isBodyHtml,
          string[] attachments,
          out string messageError)
        {
            return this.SendMail(pMails, new string[0], new string[0], pSubject, pBody, isBodyHtml, attachments, out messageError, (Dictionary<string, Stream>)null);
        }

        public bool SendMail(
          string[] pMails,
          string[] pBccMails,
          string[] pCCMails,
          string pSubject,
          string pBody,
          bool isBodyHtml,
          string[] attachments,
          out string messageError)
        {
            return this.SendMail(pMails, pBccMails, pCCMails, pSubject, pBody, isBodyHtml, attachments, out messageError, (Dictionary<string, Stream>)null);
        }

        public bool SendMail(
          string[] pMails,
          string[] pBccMails,
          string[] pCCMails,
          string pSubject,
          string pBody,
          bool isBodyHtml,
          string[] attachments,
          out string messageError,
          Dictionary<string, Stream> stearmAttachments)
        {
            messageError = string.Empty;
            logic_acces logicAcces = new logic_acces(BasePage.ConexionDB);
            string str1 = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "1"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            string host = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "2"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            string str2 = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "3"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            string password = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "4"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            string displayName = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "5"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            if (str1 == "0")
            {
                messageError = "No esta configurado el sistema para envio de correos, favor de verificar.";
                return false;
            }
            if (!(str1 == "1"))
                return false;
            try
            {
                SmtpClient smtpClient = new SmtpClient(host);
                smtpClient.Credentials = (ICredentialsByHost)new NetworkCredential(str2, password);
                MailMessage message = new MailMessage();
                message.From = new MailAddress(str2, displayName);
                string str3 = " <style type=\"text/css\"> body, p, table, div, ul, li  {font-family:\"Verdana\", \"Arial\"; font-weight:normal; font-size:12px; } </style> ";
                message.Subject = pSubject;
                message.IsBodyHtml = isBodyHtml;
                message.Body = str3 + pBody;
                foreach (string pMail in pMails)
                {
                    if (pMail != "")
                        message.To.Add(pMail.Trim());
                }
                foreach (string pBccMail in pBccMails)
                {
                    if (pBccMail != "")
                        message.Bcc.Add(pBccMail.Trim());
                }
                foreach (string pCcMail in pCCMails)
                {
                    if (pCcMail != "")
                        message.CC.Add(pCcMail.Trim());
                }
                foreach (string attachment1 in attachments)
                {
                    if (attachment1 != "" && System.IO.File.Exists(attachment1))
                    {
                        Attachment attachment2 = new Attachment(attachment1);
                        message.Attachments.Add(attachment2);
                    }
                }
                if (stearmAttachments != null)
                {
                    foreach (KeyValuePair<string, Stream> stearmAttachment in stearmAttachments)
                    {
                        Attachment attachment = new Attachment(stearmAttachment.Value, stearmAttachment.Key);
                        message.Attachments.Add(attachment);
                    }
                }
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
                return false;
            }
        }

        public bool SendMail(
          string[] pMails,
          string pSubject,
          string pBody,
          bool isBodyHtml,
          string[] attachments,
          out string messageError,
          Dictionary<string, Stream> stearmAttachments,
          string conexion)
        {
            messageError = string.Empty;
            logic_acces logicAcces = new logic_acces(conexion, false);
            string str1 = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "1"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            string host = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "2"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            string str2 = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "3"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            string password = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "4"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            string displayName = logicAcces.ExecuteQuery("get_Parametro", new Dictionary<string, string>()
      {
        {
          "parametroId",
          "5"
        }
      }).Tables[0].Rows[0]["valor"].ToString();
            if (str1 == "0")
            {
                messageError = "No esta configurado el sistema para envio de correos, favor de verificar.";
                return false;
            }
            if (!(str1 == "1"))
                return false;
            try
            {
                SmtpClient smtpClient = new SmtpClient(host);
                smtpClient.Credentials = (ICredentialsByHost)new NetworkCredential(str2, password);
                MailMessage message = new MailMessage();
                message.From = new MailAddress(str2, displayName);
                string str3 = " <style type=\"text/css\"> body, p, table, div, ul, li  {font-family:\"Verdana\", \"Arial\"; font-weight:normal; font-size:12px; } </style> ";
                message.Subject = pSubject;
                message.IsBodyHtml = isBodyHtml;
                message.Body = str3 + pBody;
                foreach (string pMail in pMails)
                {
                    if (pMail != "")
                        message.To.Add(pMail.Trim());
                }
                foreach (string attachment1 in attachments)
                {
                    if (attachment1 != "" && System.IO.File.Exists(attachment1))
                    {
                        Attachment attachment2 = new Attachment(attachment1);
                        message.Attachments.Add(attachment2);
                    }
                }
                if (stearmAttachments != null)
                {
                    foreach (KeyValuePair<string, Stream> stearmAttachment in stearmAttachments)
                    {
                        Attachment attachment = new Attachment(stearmAttachment.Value, stearmAttachment.Key);
                        message.Attachments.Add(attachment);
                    }
                }
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
                return false;
            }
        }

        public bool EnviarMail(string conexion)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);
                smtpClient.Credentials = (ICredentialsByHost)new NetworkCredential("", "");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage message = new MailMessage();
                message.From = new MailAddress("j", "NameToDisplay");
                message.To.Add(new MailAddress("j"));
                message.Body = "This is a test email. Please ignore or delete.";
                message.Subject = "Sent from C#";
                smtpClient.Send(message);
                return true;
            }
            catch (SmtpException ex)
            {
            }
            return false;
        }

        public static string SerializeOne(Dictionary<string, string> a) => new JavaScriptSerializer().Serialize((object)a);

        public static Dictionary<string, string> DeserializeOne(string json) => new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(json);

        public static string[] DeserializeArray(string json) => new JavaScriptSerializer().Deserialize<string[]>(json);

        public static void WriteLineOnTxt(string message)
        {
            string str = DateTime.Now.ToString("ddMMyyyy");
            StreamWriter streamWriter = new StreamWriter(HostingEnvironment.MapPath("~/Log/") + str + ".txt", true);
            streamWriter.WriteLine(message);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany<Control, Control>((Func<Control, IEnumerable<Control>>)(ctrl => this.GetAll(ctrl, type))).Concat<Control>(controls).Where<Control>((Func<Control, bool>)(c => c.GetType() == type));
        }

        public static string Encripta(string Password)
        {
            string str1 = "";
            try
            {
                SHA1 shA1 = SHA1.Create();
                byte[] bytes = new ASCIIEncoding().GetBytes(Password);
                shA1.ComputeHash(bytes);
                str1 = Convert.ToBase64String(shA1.Hash);
            }
            catch (Exception ex)
            {
                string str2 = "Error in HashCode : " + ex.Message;
            }
            return str1;
        }

        protected System.Data.DataTable SetColumnsName(System.Data.DataTable dt)
        {
            int count = dt.Columns.Count;
            for (int index = 0; index < count; ++index)
            {
                if (!dt.Columns[index].ColumnName.Contains("Export"))
                {
                    dt.Columns.Remove(dt.Columns[index].ColumnName);
                    --count;
                }
            }
            return dt;
        }


    }
}
