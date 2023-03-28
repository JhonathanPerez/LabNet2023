using Lab.Api.Models;
using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lab.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly CategoriesLogic categoriesLogic;

        public CategoriesController()
        {
            categoriesLogic = new CategoriesLogic();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var data = categoriesLogic.GetAll();

                IEnumerable<CategoriesDto> categories = data.Select(c => new CategoriesDto
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                });

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var data = categoriesLogic.GetOne(id);

                CategoriesDto category = new CategoriesDto();
                category.CategoryID = data.CategoryID;
                category.CategoryName = data.CategoryName;
                category.Description = data.Description;

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(CategoriesDto categoriesDto)
        {
            try
            {
                if (categoriesLogic.ItemExist(categoriesDto.CategoryName) != null)
                {
                    return BadRequest("Ya existe una categoría con ese nombre");
                }

                Categories category = new Categories();
                category.CategoryName = categoriesDto.CategoryName;
                category.Description = categoriesDto.Description;

                categoriesLogic.Add(category);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Put(int id, CategoriesDto categoriesDto)
        {
            try
            {
                if (categoriesLogic.ItemExist(id) == null)
                {
                    return BadRequest($"No existe una categoría con ID {categoriesDto.CategoryID}");
                }

                Categories category = new Categories();

                category.CategoryID = id;
                category.CategoryName = categoriesDto.CategoryName;
                category.Description = categoriesDto.Description;
                categoriesLogic.Update(category);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (categoriesLogic.ItemExist(id) == null)
                {
                    return BadRequest($"No existe una categoría con ID {id}");
                }

                categoriesLogic.Delete(id);

                return Ok("Categoría eliminada exitosamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}