using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Sheet1;

public class CreateSheet1Command : ICommand<Result<int>>
{
        public string? RequestNo { get; set; }
        public double? RequestDate { get; set; }
        public string? Company { get; set; }
        public string? Project { get; set; }
        public string? Store { get; set; }
        public string? Scope { get; set; }
        public double? Vehicle { get; set; }
        public string? Line { get; set; }
        public double? WorkOrderNo { get; set; }
        public string? F10 { get; set; }
        public string? F11 { get; set; }
        public string? F12 { get; set; }
        public string? F13 { get; set; }
        public string? F14 { get; set; }
        public string? F15 { get; set; }
        public string? F16 { get; set; }
        public string? F17 { get; set; }
        public string? F18 { get; set; }
        public string? F19 { get; set; }
        public string? F20 { get; set; }
        public string? F21 { get; set; }
        public string? F22 { get; set; }
        public string? F23 { get; set; }
        public string? F24 { get; set; }
        public string? F25 { get; set; }
        public string? F26 { get; set; }
        public string? F27 { get; set; }
        public string? F28 { get; set; }
        public string? F29 { get; set; }
        public string? F30 { get; set; }
        public string? F31 { get; set; }
        public string? F32 { get; set; }
        public string? F33 { get; set; }
        public string? F34 { get; set; }
        public string? F35 { get; set; }
        public string? F36 { get; set; }
        public string? F37 { get; set; }
        public string? F38 { get; set; }
        public string? F39 { get; set; }
        public string? F40 { get; set; }
        public string? F41 { get; set; }
        public string? F42 { get; set; }
        public string? F43 { get; set; }
}
internal class CreateSheet1CommandHandler : ICommandHandler<CreateSheet1Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateSheet1CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateSheet1Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Sheet1$] ([RequestNo], [RequestDate], [Company], [Project], [Store], [Scope], [Vehicle], [Line], [WorkOrderNo], [F10], [F11], [F12], [F13], [F14], [F15], [F16], [F17], [F18], [F19], [F20], [F21], [F22], [F23], [F24], [F25], [F26], [F27], [F28], [F29], [F30], [F31], [F32], [F33], [F34], [F35], [F36], [F37], [F38], [F39], [F40], [F41], [F42], [F43]) VALUES ({request.RequestNo}, {request.RequestDate}, {request.Company}, {request.Project}, {request.Store}, {request.Scope}, {request.Vehicle}, {request.Line}, {request.WorkOrderNo}, {request.F10}, {request.F11}, {request.F12}, {request.F13}, {request.F14}, {request.F15}, {request.F16}, {request.F17}, {request.F18}, {request.F19}, {request.F20}, {request.F21}, {request.F22}, {request.F23}, {request.F24}, {request.F25}, {request.F26}, {request.F27}, {request.F28}, {request.F29}, {request.F30}, {request.F31}, {request.F32}, {request.F33}, {request.F34}, {request.F35}, {request.F36}, {request.F37}, {request.F38}, {request.F39}, {request.F40}, {request.F41}, {request.F42}, {request.F43})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
