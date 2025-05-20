using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
public class CategoryService : ICategoryService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public IEnumerable<CategoryDto> GetAllCategories()
	{
		var categories = _unitOfWork.Categories.GetAll();
		return _mapper.Map<IEnumerable<CategoryDto>>(categories);
	}

	public CategoryFormDto? GetCategoryById(int id)
	{
		var category = _unitOfWork.Categories.FindById(id);

		return _mapper.Map<CategoryFormDto>(category);
	}

	public CategoryDto? UpdateCategory(CategoryFormDto categoryDto)
	{
		var existingCategory = _unitOfWork.Categories.FindById(categoryDto.Id);

		if (existingCategory == null)
		{
			return null;
		}

		_mapper.Map(categoryDto, existingCategory);

		_unitOfWork.SaveChanges();

		return _mapper.Map<CategoryDto>(existingCategory);
	}

	public CategoryDto CreateCategory(CategoryFormDto categoryDto)
	{
		var category = _mapper.Map<Category>(categoryDto);
		_unitOfWork.Categories.Insert(category);
		_unitOfWork.SaveChanges();

		return _mapper.Map<CategoryDto>(category);
	}

	public DateTime? ChangeStatus(int id)
	{
		var existingCategory = _unitOfWork.Categories.FindById(id);

		if (existingCategory == null)
			return null;

		existingCategory.IsDeleted = !existingCategory.IsDeleted;
		existingCategory.LastUpdatedOn = DateTime.Now;

		_unitOfWork.Categories.Update(existingCategory);

		_unitOfWork.SaveChanges();

		return existingCategory.LastUpdatedOn;
	}
}
