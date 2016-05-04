using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Microsoft.BusinessData.Infrastructure.SecureStore;
using Microsoft.BusinessData.MetadataModel;
using Microsoft.BusinessData.Runtime;
using Microsoft.BusinessData.SystemSpecific;
using Microsoft.Office.SecureStoreService.Server;
using Microsoft.SharePoint;

namespace Modelos.Alumnos
{
    
    public class AlumnoService:IContextProperty
    {
        public IMethodInstance MethodInstance { get; set; }
        public ILobSystemInstance LobSystemInstance { get; set; }
        public IExecutionContext ExecutionContext { get; set; }
        public static string username = "";
        public static string password = "";

        // obtener las credenciales
        public static void GetCredenciales(out string user, out string pwd)
        {
            // ir al secure store service
            // aqui vamos a guardar el secure app id
            var appId = "Alumnos";

            // por ser OUT voy asignar valor
            user = ""; 
            pwd = "";

            // necesitamos el secure storage provider, el cual nos dara acceso
            ISecureStoreProvider provider = SecureStoreProviderFactory.Create();
            ISecureStoreServiceContext providerContext = provider as ISecureStoreServiceContext;
            providerContext.Context = SPServiceContext.GetContext(new SPSite("http://pruebassp2"));


            using (var creds = provider.GetCredentials(appId))
            {
                if (creds != null) {
                    foreach (var c in creds)
                    {
                        if (c.CredentialType == SecureStoreCredentialType.UserName)
                        {
                            user = GetCredentialFromStrong(c.Credential);

                        }
                        else if (c.CredentialType== SecureStoreCredentialType.Password)
                        {
                            pwd= GetCredentialFromStrong(c.Credential);
                        }
                    }
                }
            }
        }

        private static string GetCredentialFromStrong(SecureString credential)
        {
            if (credential == null)
            {
                return null;
            }
            // genera un puntero en el sistema
            // tengo la direccion de memoria
            IntPtr texto = IntPtr.Zero;
            try
            {
                // las librerias de marshalling permiten hacer llamdas a codigo NO manejado
                // la llamada a Com+ de windows
                // es decir que no existe en C Sharp
                // a travez de librerias propias del sistema
                // convierte u8na cadena ya cifrada en un puntero

                texto = Marshal.SecureStringToBSTR(credential);

                // convierte el puntero en String
                return Marshal.PtrToStringBSTR(texto);
            }
            finally 
            {
                // si lo encontre
                // libero el puntero
                if (texto != IntPtr.Zero)
                {
                    // libera y limpia
                    Marshal.FreeBSTR(texto);
                }
            }
            
        }
        
        public static Alumno ReadItem(int id)
        {
            // voy a recuperar las credenciales
            string pwd = "";
            string user = "";
            GetCredenciales(out user,out pwd);

            // voy a conectar a la base de datos

            Alumno alumno = new Alumno();
            return alumno;
        }
        
        public static IEnumerable<Alumno> ReadList()
        {
        
            Alumno[] alumnoList = new Alumno[1];
            Alumno alumno = new Alumno();
        
            alumnoList[0] = alumno;
            return alumnoList;
        }

        public static void Delete()
        {
            throw new System.NotImplementedException();
        }


        
    }

        
    }

