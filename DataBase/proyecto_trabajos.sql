-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: proyecto
-- ------------------------------------------------------
-- Server version	9.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `trabajos`
--

DROP TABLE IF EXISTS `trabajos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trabajos` (
  `TrabajoID` int NOT NULL AUTO_INCREMENT,
  `MatriculaID` int NOT NULL,
  `Empresa` varchar(255) DEFAULT NULL,
  `Puesto` varchar(150) NOT NULL,
  `Funciones` varchar(150) NOT NULL,
  `Logros` varchar(150) NOT NULL,
  `FechaIniFin` varchar(150) NOT NULL,
  PRIMARY KEY (`TrabajoID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trabajos`
--

LOCK TABLES `trabajos` WRITE;
/*!40000 ALTER TABLE `trabajos` DISABLE KEYS */;
INSERT INTO `trabajos` VALUES (1,1,'Microsoft','Ingeniero de Software','Escribir código limpio y mantenible en C#, participar en code reviews, implementar pruebas automatizadas.','Optimicé un proceso crítico reduciendo su tiempo de ejecución de 30 minutos a 3 minutos.','Jun 2023 - Oct 2023'),(2,1,'Amazon','Desarrollador Backend','Diseñar APIs con alta disponibilidad, gestionar bases de datos SQL y NoSQL, garantizar seguridad en los endpoints.','Implementé un sistema de caché distribuida que redujo la carga en los servidores en un 35%.','Ago 2024 - Dic 2024'),(3,1,'Globant','Programador Junior','Asistir en el desarrollo de features, corregir bugs documentados, escribir tests unitarios.','Participé en el lanzamiento de 3 funcionalidades clave para un cliente del sector bancario.','Ene 2025 - Mar 2025'),(4,1,'Google','Desarrollador Full Stack','Desarrollo de aplicaciones web escalables, optimización de bases de datos, integración de APIs RESTful.','Migré una plataforma legacy a microservicios, reduciendo los tiempos de respuesta en un 40%.','May 2025 - Dic 2026');
/*!40000 ALTER TABLE `trabajos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-26 17:18:09
