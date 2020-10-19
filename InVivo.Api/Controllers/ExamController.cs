using InVivo.Domain.Commands.Handlers;
using InVivo.Domain.Commands.Inputs;
using InVivo.Domain.Repositories;
using InVivo.Infrastructure.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InVivo.Api.Controllers
{
    public class ExamController: BaseController
    {
        private readonly IExamLabRepository _repository;
        private readonly ExamLabCommandHandler _handler;

        public ExamController(IUow uow, IExamLabRepository repository, ExamLabCommandHandler handler) 
            : base(uow)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("exames/{id}")]
        public IActionResult Get(Guid id)
        {
            var data = _repository.GetById(id);
            return Ok(data);

        }

        [HttpPost]
        [Route("exames")]
        public async Task<IActionResult> Post([FromBody] RegisterExamLabCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);

        }

    }
}
