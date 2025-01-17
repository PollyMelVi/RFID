using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Common.EF;
using RFLOT.Infrastructure.Report.EntityConfigurations;

namespace RFLOT.Infrastructure.Report;

public class ReportDbContext : DbContext, IEventPublisher
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    private readonly IMediator _mediator;

    public DbSet<Domain.Report.Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReportConfiguration());
        //modelBuilder.ApplyConfiguration(new ZoneReportConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured) throw new InvalidOperationException("Context was not configured");

        base.OnConfiguring(optionsBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync<Guid>(this);
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}