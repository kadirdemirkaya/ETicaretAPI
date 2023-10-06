using AutoMapper;
using ETicaretAPI.application.DTOs.Category;
using ETicaretAPI.application.Repositories;
using MediatR;

namespace ETicaretAPI.application.Mediators.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        private readonly IMapper mapper;

        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            this.categoryReadRepository = categoryReadRepository;
            this.mapper = mapper;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            List<ETicaretAPI.domain.Entites.Category> categories = await categoryReadRepository.GetAllAsync();
            var map = mapper.Map<List<GetAllCategoryDto>>(categories);
            return new() { GetAllCategoryDtos = map };
        }
    }
}
