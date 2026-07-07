using Microsoft.AspNetCore.Mvc;
using VrAudioCena.WebApi.Core.Events;
using VrAudioCena.WebApi.Infrastructure.Background;
using VrAudioCena.WebApi.Infrastructure.Persistence;

namespace VrAudioCena.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SceneController : ControllerBase
    {
        private readonly IOperationRepository _operationRepository;
        private readonly EventQueue _eventQueue;
        private readonly MediatR.IMediator _mediator;

        public SceneController(IOperationRepository operationRepository, EventQueue eventQueue, MediatR.IMediator mediator  )
        {
            _operationRepository = operationRepository;
            _eventQueue = eventQueue;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var content = @"
Bom dia a todos.

Meu nome é Allan e hoje vou apresentar o projeto My VR Academia, uma plataforma em realidade virtual desenvolvida para auxiliar estudantes universitários no treinamento de apresentações acadêmicas.

Falar em público é uma habilidade essencial durante a graduação, seja para apresentar seminários, trabalhos de conclusão de curso ou pesquisas científicas. No entanto, muitos estudantes sentem ansiedade e não possuem oportunidades para praticar em um ambiente seguro antes da apresentação real.

Pensando nesse problema, desenvolvemos o My VR Academia. O sistema utiliza realidade virtual para simular diferentes cenários de apresentação, permitindo que o usuário pratique como se estivesse diante de uma plateia real.

Durante a simulação, o estudante realiza sua apresentação enquanto o sistema coleta diferentes métricas. Entre elas estão o tempo de apresentação, a intensidade da voz, a quantidade de pausas, além da interação com um público virtual.

Outro diferencial da plataforma é a utilização de inteligência artificial. Após o término da apresentação, a IA analisa o conteúdo apresentado e gera perguntas que poderiam ser feitas por uma banca avaliadora ou pelo público presente. Em seguida, essas perguntas são convertidas em áudio por um sistema de síntese de voz, tornando a experiência ainda mais imersiva.

O backend da aplicação foi desenvolvido em C# utilizando ASP.NET, enquanto a aplicação de realidade virtual foi construída na Unity. A comunicação entre os componentes ocorre por meio de uma arquitetura orientada a eventos, permitindo que tarefas como extração de texto, processamento pela IA e geração de áudio sejam executadas de forma assíncrona.

Como trabalhos futuros, pretendemos avaliar diferentes níveis de imersão em realidade virtual, integrar sensores fisiológicos para medir indicadores de ansiedade e realizar estudos com estudantes universitários para validar a eficácia da plataforma.

Em conclusão, o My VR Academia busca oferecer uma ferramenta acessível para que estudantes possam praticar apresentações acadêmicas, receber feedback automático e desenvolver maior confiança para falar em público.

Muito obrigado pela atenção. Estou à disposição para responder às perguntas.";
            _mediator.Publish(new StartAiProcessingEvent(content));
            return Ok();
        }

        [HttpPost("start")]
        public async Task<IActionResult> UploadPdf (IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }

            if (Path.GetExtension(file.FileName).ToLower() != ".pdf")
            {
                return BadRequest("Apenas arquivos PDF são permitidos.");
            }

            var id = Guid.NewGuid();

            _operationRepository.Start(id);

           // _eventQueue.EnqueueAsync(new StartAiProcessingEvent(...));

            return Accepted(new {operationId = id});
        }
    }   
}