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

    public IEnumerable<CategoryListDto> GetAllCategories()
    {
        var categories = _unitOfWork.Categories.GetAll();
        return _mapper.Map<IEnumerable<CategoryListDto>>(categories);
    }

    public Category GetCategoryById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }


    public void DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }

    public void CreateCategory(CreateCategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        _unitOfWork.Categories.Insert(category);
        _unitOfWork.SaveChanges();
    }
}
