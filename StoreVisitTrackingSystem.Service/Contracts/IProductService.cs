﻿using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IProductService
{
    Task<int> CreateProductAsync(ProductRequestDTO productRequestDTO, CancellationToken cancellationToken = default);
    Task<PaginationDTO<ProductDTO>> GetAllProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
