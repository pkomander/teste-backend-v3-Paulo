using Aiko.Dto;
using Aiko.Repository.Context;
using Aiko.Repository.Services.Interface;
using Aiko.Repository.Services.Repository;
using ApprovalTests;
using ApprovalTests.Reporters;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ApprovalTest
{
    public class StatementPrinterTests
    {
        private readonly IExtratoService _extratoService;
        private readonly DataContext _context;

        public StatementPrinterTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer("server=localhost;database=AikoTeste;user=sa;password=#sa123456;TrustServerCertificate=true;")
            .Options;

            _context = new DataContext(options);

            // Criar mocks das dependências
            //var mockContext = new Mock<DataContext>();
            //var context = new DataContext(options);
            var mockMapper = new Mock<IMapper>();

            _extratoService = new ExtratoService(_context, mockMapper.Object);
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public async void TestTextStatementExample()
        {
            var objectTeste = new ExtratoRequest
            {
                InvoiceId = 1,
                Custumer = null,
                FormatoArquivo = 2
            };

            var gerarTexto = await _extratoService.GerarExtrato(objectTeste);

            Approvals.Verify(gerarTexto.Successes.FirstOrDefault());
            //Assert.True(gerarTexto.IsSuccess);
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public async void TestXmlStatementExample()
        {
            var objectTeste = new ExtratoRequest
            {
                InvoiceId = 1,
                Custumer = null,
                FormatoArquivo = 1
            };

            var gerarTexto = await _extratoService.GerarExtrato(objectTeste);

            Approvals.Verify(gerarTexto.Successes.FirstOrDefault());
            //Assert.True(gerarTexto.IsSuccess);
        }
    }
}
