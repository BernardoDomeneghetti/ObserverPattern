using System;
using ObserverPattern.Abstractions.Application.Services;
using ObserverPattern.Application.Commands;
using ObserverPattern.Application.Responses;
using ObserverPattern.Domain.Abstractions;

namespace ObserverPattern.Application.Services;

public class OperationLoggerService: 
    IApplicationService<OperationLogCommand, OperationLogResponse>,
    ICustomObserver<UpdateProductStorageCommand>
{
    public async Task<OperationLogResponse> ExecuteAsync(OperationLogCommand command)
    {
        await Task.Delay(100); 
        Console.WriteLine(command.LogMessage);

        return new OperationLogResponse("Operation logged successfully.");
    }

    public Task UpdateAsync(UpdateProductStorageCommand command)
    {
        var OperationLogCommand = new OperationLogCommand
        {
            LogMessage = $"Product storage updated: ProductId={command.ProductId}, MovementType={command.MovementType}, Amount={command.MovementAmount}"
        };
        return ExecuteAsync(OperationLogCommand);
    }
}
