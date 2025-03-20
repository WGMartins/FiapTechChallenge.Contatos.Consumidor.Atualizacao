using Domain.Interfaces;
using FluentValidation;
using UseCase.Interfaces;

namespace UseCase.ContatoUseCase.Alterar
{
    public class AlterarContatoUseCase : IAlterarContatoUseCase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IValidator<AlterarContatoDto> _validator;

        public AlterarContatoUseCase(IContatoRepository contatoRepository, IValidator<AlterarContatoDto> validator)
        {
            _contatoRepository = contatoRepository;
            _validator = validator;
        }

        public void Alterar(AlterarContatoDto alterarContatoDto)
        {
            var validacao = _validator.Validate(alterarContatoDto);
            if (!validacao.IsValid)
            {
                string mensagemValidacao = string.Empty;
                foreach (var item in validacao.Errors)
                {
                    mensagemValidacao = string.Concat(mensagemValidacao, item.ErrorMessage, ", ");
                }

                throw new Exception(mensagemValidacao.Remove(mensagemValidacao.Length - 2));
            }

            var contato = _contatoRepository.ObterPorId(alterarContatoDto.Id);

            if (contato is null)
            {
                throw new Exception("Contato não encontrado");
            }

            contato.Alterar(alterarContatoDto.Nome, alterarContatoDto.Telefone, alterarContatoDto.Email, alterarContatoDto.RegionalId);

            _contatoRepository.Alterar(contato);
        }
    }
}
