# PushUpClaySeguridad_

## Consultas requeridas

  1) Listar todos los empleados de la empresa de seguridad
  * Ruta: http://localhost:5116/api/Persona/empleados
    * Metodo:
    ```C#
      public async Task<IEnumerable<Persona>> GetListarEmpleados()
        {
            var empleados = await _context.Personas
            .Where(e=>e.IdTipoPersonaNavigation.Descripcion.ToLower() == "empleado")
            .ToListAsync();

            return empleados;
        }
    ```
    * Respuesta:
      
      ![image](https://github.com/OSCARJMG23/PushUpClaySeguridad_/assets/133609079/d642cdf5-d712-417a-91d8-5c49c436c940)

      
  
  2) Listar todos los empleados que son vigilantes
  * Ruta: http://localhost:5116/api/Persona/empleadosVigilantes
    * Metodo:
    ```C#
      public async Task<IEnumerable<Persona>> GetListarEmpleadosVigilantes()
        {
            var empleados = await _context.Personas
            .Where(e=>e.IdTipoPersonaNavigation.Descripcion.ToLower() == "empleado" &&
              e.IdCategoriaNavigation.NombreCategoria.ToLower() == "vigilante")
            .ToListAsync();

            return empleados;
        }
    ```
    * Respuesta:
   
      ![image](https://github.com/OSCARJMG23/PushUpClaySeguridad_/assets/133609079/fd1dd6a2-216a-444d-bdc3-b15499ba0606)

  
  3) Listar los numeros de contacto de un empledo que sea vigilante
  * Ruta: http://localhost:5116/api/ContactoPersona/empleadosvigilantes
    * Metodo:
    ```C#
      public async Task<IEnumerable<object>> GetListarContactoEmpleadoVigilante()
        {
            var contactosVigilantes = await _context.ContactoPersonas
            .Where(e=> e.IdPersonaNavigation.IdTipoPersonaNavigation.Descripcion.ToLower() == "empleado" 
                && e.IdPersonaNavigation.IdCategoriaNavigation.NombreCategoria.ToLower() == "vigilante")
            .Select(e=>new
            {
                Contacto = e.Descripcion
            }).ToListAsync();

            return contactosVigilantes;
        }
    ```
    * Respuesta:
   
      ![image](https://github.com/OSCARJMG23/PushUpClaySeguridad_/assets/133609079/07dd8952-53ad-4ad4-be9c-a1cdbb0228e8)

  
  4) Listar todos los clientes que vivan en la ciudad de Bucaramanga
  * Ruta: http://localhost:5116/api/Persona/clientesvivanbga
    * Metodo:
    ```C#
      public async Task<IEnumerable<Persona>> GetClientesVivanBGA()
        {
            var Clientes = await _context.Personas
            .Where(e=>e.IdTipoPersonaNavigation.Descripcion.ToLower() == "cliente"  &&
              e.IdCiudadNavigation.NombreCiudad.ToLower() == "bucaramanga")
            .ToListAsync();

            return Clientes;
        }
    ```
    * Respuesta:

      ![image](https://github.com/OSCARJMG23/PushUpClaySeguridad_/assets/133609079/8e842387-da01-4780-95f9-857bf3cf2913)

  
  5) Listar todos los empleados que vivan en giron y piedecuesta
  * Ruta: http://localhost:5116/api/Persona/empladosVivangironOPiedecuesta
    * Metodo:
    ```C#
      public async Task<IEnumerable<Persona>> GetEmpleadosVivangironOPiedecuesta()
        {
            var empleados = await _context.Personas
            .Where(e=>e.IdTipoPersonaNavigation.Descripcion.ToLower() == "empleado" 
                && e.IdCiudadNavigation.NombreCiudad.ToLower() == "giron" ||
                e.IdCiudadNavigation.NombreCiudad.ToLower() == "piedecuesta")
            .ToListAsync();

            return empleados;
        }
    ```
    * Respuesta:
   
      ![image](https://github.com/OSCARJMG23/PushUpClaySeguridad_/assets/133609079/ea3589a9-3a2c-4965-b7bb-3e62df3356d7)

  
  6) Listar todos los clientes que tengan mas de 5 años de antiguedad
  * Ruta: http://localhost:5116/api/Persona/clientesmas5añosantiguedad
    * Metodo:
    ```C#
      public async Task<IEnumerable<Persona>> GetClientesMas5AñosAntiguedad()
        {
            var fechaActual = DateTime.Now;
            
            var Clientes = await _context.Personas
                .Where(e => e.IdTipoPersonaNavigation.Descripcion.ToLower() == "cliente" &&
                            e.DateRegistro.HasValue &&
                            fechaActual.Year - e.DateRegistro.Value.Year > 5)
                .ToListAsync();

            return Clientes;
        }
    ```
    * Respuesta:

      ![image](https://github.com/OSCARJMG23/PushUpClaySeguridad_/assets/133609079/b12c05f5-14e8-4230-af17-e0f844c34e36)

  
  7) Listar todos los contratos cuyo estado es Activo. Se debe mostrar el Nro de contrato, el nombre del cliente y el        empleado que registro el contrato
  * Ruta: http://localhost:5116/api/Contrato/estadoactivo
    * Metodo:
    ```C#
      public async Task<IEnumerable<object>> GetContratoEstadoActivo()
        {
            var contratos = await _context.Contratos
            .Where(e=>e.IdEstadoNavigation.Descripcion.ToLower() == "activo")
            .Select(e=>new
            {
                NroContrato = e.Id,
                NombreCliente = e.IdClienteNavigation.Nombre,
                NombreEmpleado = e.IdEmpleadoNavigation.Nombre
            }).ToListAsync();

            return contratos;
        }
    ```

    * Respuesta:
   
      ![image](https://github.com/OSCARJMG23/PushUpClaySeguridad_/assets/133609079/c2be396d-fb54-44d0-a6a0-e05c72b70864)

  * Nota: Todos los controladores tienen un endpoint con el metodo get donde se agrega la paginacion
    * Ejemplo Ruta: http://localhost:5116/api/CategoriaPersona/paginado
    * Respuesta
      
    ![image](https://github.com/OSCARJMG23/PushUpClaySeguridad_/assets/133609079/38ee9d74-63c3-4eea-b813-320a5b66d451)

  ## Rutas JWT
  * Register: http://localhost:5116/api/User/register
  * Token: http://localhost:5116/api/User/token
  * AddRole: http://localhost:5116/api/User/addrole
  * RefreshToken: http://localhost:5116/api/User/refresh-token

  * Por ultimo Aclarar que se cumple con todos lo requrimientos, se usa ratelimit, jwt, Dtos, unidades de trabajo, paginacion y los Crud.
