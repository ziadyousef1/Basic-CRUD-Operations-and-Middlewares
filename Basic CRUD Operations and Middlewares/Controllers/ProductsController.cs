    using Basic_CRUD_Operations_and_Middlewares.Models;
    using Basic_CRUD_Operations_and_Middlewares.Repository;
    using Microsoft.AspNetCore.Mvc;

    namespace Basic_CRUD_Operations_and_Middlewares.Controllers
    {
        [Route("[controller]")]
        public class ProductsController : Controller
        {
            private readonly IProductRepository _repository;

            public ProductsController(IProductRepository repository)
            {
                _repository = repository;
            }

            public IActionResult Index()
            {
                var products = _repository.GetAll();
                return View(products);
            }

            public IActionResult Details(int id)
            {
                var product = _repository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]

            public IActionResult Create(Product product)
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            [Route("Edit")]

            public IActionResult Edit(int id)
            {
                var product = _repository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

            [HttpPost]
            [Route("Edit")]

            public IActionResult Edit(Product product)
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            [Route("Index")]


            public IActionResult Delete(int id)
            {
                var product = _repository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

            [HttpPost, ActionName("Delete")]
            public IActionResult DeleteConfirmed(int id)
            {
                _repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }

