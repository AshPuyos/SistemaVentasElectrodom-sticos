# Sistema de Ventas de Electrodomésticos

Este proyecto es un sistema de información diseñado para una casa de electrodomésticos, que permite llevar el control de promociones de calefactores eléctricos y a gas. El sistema está implementado en C# y se centra en la gestión de clientes y proveedores, así como en la adquisición de calefactores.

Los clientes pueden comprar un calefactor a la vez y obtener descuentos según el tipo de calefactor adquirido: un 25% para los calefactores a gas y un 15% para los eléctricos. La información sobre los calefactores, clientes y proveedores se almacena en una base de datos SQL Server.

## Características

- **Modelo de Clases**: Desarrollo de un modelo de clases que representa la lógica del sistema.
- **Base de Datos**: Implementación con SQL Server, incluyendo un backup (.bak) y script de creación de base de datos.
- **Interfaz Gráfica MDI**: Diseño de una interfaz amigable para el usuario con formularios ABM, DataGridView y combos.
- **Control de Stock**: Validación del stock disponible y control de adquisiciones.
- **Gestión de Descuentos**: Aplicación de descuentos basados en el tipo de calefactor adquirido.
- **Errores y Excepciones**: Captura de todos los errores, incluidos los de SQL, para garantizar la estabilidad del sistema.
- **Transacciones**: Manejo de transacciones para asegurar la integridad de los datos.
- **Informes**: Generación de informes sobre calefactores adquiridos por cliente y los más y menos solicitados.

## Tecnologías Utilizadas

- C# .NET Framework
- SQL Server
- Visual Studio
- ADO.NET
