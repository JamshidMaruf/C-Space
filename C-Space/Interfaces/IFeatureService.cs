using C_Space.Models;

namespace C_Space.Interfaces;

public interface IFeatureService
{
    Feature Create(Feature feature);
    Feature Update(int id, Feature feature);
    bool Delete(int id);
    Feature GetById(int id);
    List<Feature> GetAll();
}
