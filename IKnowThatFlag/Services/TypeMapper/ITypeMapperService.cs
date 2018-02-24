using System;
namespace IKnowThatFlag.Services
{
    public interface ITypeMapperService
    {
        Type MapViewModelToView(Type viewModelType);
        Type MapViewToViewModel(Type vType);
    }
}