using AutoMapper;
using MediatR;
using Praktika.Application.Categories.DTOs;
using Praktika.Praktika.Domain.Entities;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Categories.Commands.CreateCategory
{

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly PraktikaDbContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(PraktikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}