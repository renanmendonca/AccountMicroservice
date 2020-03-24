using MediatR;

namespace Account.Domain.Commands
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
        void Validate();
    }
}
