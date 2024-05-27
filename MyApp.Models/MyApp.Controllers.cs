using MyApp.Models;

namespace MyApp.Controllers
{
    public class MyModelsController : Controller
    {
        private readonly string filePath = "data.json";

        private List<MyModel> LoadModels()
        {
            if (!System.IO.File.Exists(filePath))
            {
                return new List<MyModel>();
            }

            var jsonData = System.IO.File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<MyModel>>(jsonData) ?? new List<MyModel>();
        }

        private void SaveModels(List<MyModel> models)
        {
            var jsonData = JsonConvert.SerializeObject(models);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        public IActionResult Index()
        {
            var models = LoadModels();
            return View(models);
        }

        private IActionResult View(List<MyModel> models)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create()
        {
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        private IActionResult View(MyModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(MyModel model)
        {
            var models = LoadModels();
            model.Id = models.Any() ? models.Max(m => m.Id) + 1 : 1;
            models.Add(model);
            SaveModels(models);
            return RedirectToAction(nameof(Index));
        }

        private IActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(int id)
        {
            var models = LoadModels();
            var model = models.FirstOrDefault(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit(MyModel model)
        {
            var models = LoadModels();
            var existingModel = models.FirstOrDefault(m => m.Id == model.Id);
            if (existingModel == null)
            {
                return NotFound();
            }
            existingModel.Name = model.Name;
            existingModel.IsActive = model.IsActive;
            existingModel.Age = model.Age;
            existingModel.Salary = model.Salary;
            existingModel.BirthDate = model.BirthDate;
            SaveModels(models);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var models = LoadModels();
            var model = models.FirstOrDefault(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            models.Remove(model);
            SaveModels(models);
            return RedirectToAction(nameof(Index));
        }
    }
}
