using Microsoft.Extensions.Logging;
using RazorWebApplication.MyClasses;
using System;
using System.Threading.Tasks;
using RazorWebApplication.MyDbContexts;
using Microsoft.Extensions.DependencyInjection;

namespace RazorWebApplication.Pages
{
    /// <summary>
    /// Добавление новой песни
    /// </summary>
    public class AddTextModel : BasePageModel
    {
        private readonly ILogger<AddTextModel> _logger;

        //public AddTextModel(RazorDbContext injectedContext, ILogger<AddTextModel> logger) : base(injectedContext)
        public AddTextModel(IServiceScopeFactory serviceScopeFactory, ILogger<AddTextModel> logger) : base(serviceScopeFactory)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                //await using (var database = new RazorDbContext())
                using (var scope = _serviceScopeFactory.CreateScope())//
                {
                    var database = scope.ServiceProvider.GetRequiredService<RazorDbContext>();//
                    
                    await CreateCheckboxesNamesAsync(database);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[AddTextModel]");
            }
        }

        public async Task OnPostAsync()
        {
            if (AreChecked.Count == 0 || TextFromHtml == null || TitleFromHtml == null)
            {
                await OnGetAsync();
                return;
            }
            try
            {
                //await using (var database = new RazorDbContext())
                using (var scope = _serviceScopeFactory.CreateScope())//
                {
                    var database = scope.ServiceProvider.GetRequiredService<RazorDbContext>();//
                    
                    await AddSongToDatabaseAsync(database);
                    await CreateTextAndTitleAsync(database, SavedTextId);
                }
                await OnGetAsync();//
                InitCheckedGenres();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[AddTextModel]");
                await OnGetAsync();//
            }
        }
    }
}
