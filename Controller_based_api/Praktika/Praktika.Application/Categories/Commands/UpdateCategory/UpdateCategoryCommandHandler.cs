using AutoMapper;
using MediatR;
using Praktika.Application.Categories.DTOs;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Categories.Commands.UpdateCategory
{

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly PraktikaDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(PraktikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (category == null)
                return null;

            category.Name = request.Name;
            category.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}