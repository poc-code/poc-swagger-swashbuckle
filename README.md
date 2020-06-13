# poc-swagger-swashbuckle

### Informações

- Em propriedades do projeto Depurar -> Configurações do Servidor Web é necessário desabilitar a opção Habilitar SSL e em Compilar -> Saída -> Arquivo de documentação XML é preciso definir o arquivo xml para que as descrições da api e dos endpoints apareçam na documentação do swagger ;
- Este projeto ha deixa o cors permitido para quaisquer requisições

#### Agrupando apis no documento swagger

##### Configuração no Startup

    public void ConfigureServices(IServiceCollection services)
        {
			...
			#region Configuração do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Api Group 01",
                        Version = "v1"
                    }
                    );
                c.SwaggerDoc(
                    "v2",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Api Group 02",
                        Description = "A simple example ASP.NET Core Web API",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Shayne Boyer",
                            Email = string.Empty,
                            Url = new Uri("https://twitter.com/johndoe"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license"),
                        }
                    }
                    );
                
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion
		}
		
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
		...
		#region Configuração do Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "MyGroupApi1 API V1");
                c.SwaggerEndpoint($"/swagger/v2/swagger.json", "MyGroupApi2 API V1");
                //c.RoutePrefix = "customer/swagger";
            });
            #endregion
		}
	</pre>

###### Configuração na controller do agrupador 01
    <pre>
    {
     /// <summary>
    /// Serviço para imprimir valores 
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Produces("application/json")]
    [Route("api/v1/values")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Retorna uma lista de valores
        /// </summary>
        /// <returns>Busca os valores</returns>
        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok("Retorna o valor de get");
        }
    }
	</pre>

###### Configuração na controller do agrupador 02
    csharp
     /// <summary>
    /// Serviço para imprimir valores 
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    [Produces("application/json")]
    [Route("api/v1/any")]
    public class AnyController : Controller
    {
        /// <summary>
        /// Qualquer retorno
        /// </summary>
        /// <returns>Busca os valores</returns>
        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok("Retorna um valor qualquer");
        }
    }

Execute o projeto e veja com o resultado
