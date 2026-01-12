# Seveclie – Prueba Técnica Full Stack (.NET)

Este proyecto corresponde a la **prueba técnica Full Stack** desarrollada en **ASP.NET Web Forms (.NET Framework 4.5.2)**, cumpliendo los lineamientos solicitados y aplicando una arquitectura en capas inspirada en **DDD (Domain Driven Design)**.

---

## 🏗️ Arquitectura del Proyecto

El sistema está estructurado en **capas bien definidas**, separando responsabilidades:

Seveclie
│
├── Seveclie.Web → Capa de Presentación (ASP.NET Web Forms)
│ ├── Clientes.aspx
│ ├── Login.aspx
│ ├── Reportes
│ │ └── ClientesReport.rdlc
│
├── Seveclie.Application → Capa de Lógica de Negocio
│ └── Services
│
├── Seveclie.Domain → Capa de Dominio
│ ├── Entities
│ ├── Interfaces
│ └── DTOs
│
├── Seveclie.Infrastructure → Capa de Acceso a Datos (ADO.NET)
│ ├── Repositories
│ └── Db


✔ Separación de responsabilidades  
✔ Fácil mantenimiento y escalabilidad  
✔ Cumple el requerimiento de capas (Páginas, Lógica, Acceso a Datos, Objetos)

---

## 🧰 Tecnologías Utilizadas

- ASP.NET Web Forms (.NET Framework 4.5.2)
- ADO.NET
- SQL Server
- Bootstrap (solo estilos, sin plantillas)
- jQuery
- ReportViewer (RDLC)
- Arquitectura en capas (DDD-like)

---

## 📋 Funcionalidades Implementadas

### ✔ Mantenimiento de Clientes
- Crear, editar, eliminar y consultar clientes
- Filtro por nombre, cédula u otros criterios
- Validaciones completas en frontend (jQuery)

### ✔ Estado Civil
- Cargado dinámicamente desde la base de datos
- Consumo mediante ADO.NET
- Sin valores quemados

### ✔ Fecha de Nacimiento
- Input tipo `date` con calendario nativo
- Validación: no permite fechas actuales ni futuras

### ✔ Validaciones (Plus)
- Cédula solo números
- Nombre sin números
- Campos obligatorios
- Mensajes por campo
- Botón Guardar deshabilitado hasta cumplir validaciones

### ✔ Autenticación
- Pantalla de Login (usuario y contraseña)
- Autenticación mediante **Forms Authentication**
- Manejo de sesión por **Cookies**
- Protección de páginas (Clientes solo accesible si hay sesión)
- Botón de **Cerrar Sesión**

### ✔ Reportes
- Reporte de clientes usando **ReportViewer**
- RDLC (`ClientesReport.rdlc`)
- Refleja filtros aplicados en la consulta

### ✔ Base de Datos
- Uso exclusivo de **ADO.NET**
- Procedimientos almacenados con:
  - TRY / CATCH
  - Transacciones
  - COMMIT / ROLLBACK

---
