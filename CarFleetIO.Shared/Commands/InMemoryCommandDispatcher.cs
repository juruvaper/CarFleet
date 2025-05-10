using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace CarFleetIO.Shared.Commands

{
    internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;


        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand_
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

            //wymaga aby klasa implementująca dany interfejs była zarejestrowana w DI kontenerze - 'get required service'. Inaczej
            //wyrzuci wyjątek

            await handler.HandleAsync(command);
        }
    }
}


//The DI system automatically resolves dependencies that are registered in the container.

//ServiceProvider is a core service in ASP.NET Core, so it's always available.

//When AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>() is called, the DI container knows:

//ICommandDispatcher should resolve to InMemoryCommandDispatcher.

//InMemoryCommandDispatcher requires IServiceProvider.

//IServiceProvider is already available, so it injects it automatically.
