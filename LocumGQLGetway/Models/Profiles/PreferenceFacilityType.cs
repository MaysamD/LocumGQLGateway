using System.ComponentModel.DataAnnotations.Schema;

namespace LocumGQLGateway.Models.Profiles;

[Table("preference_facility_types")]
public class PreferenceFacilityType
{
    [Column("preference_id")]
    public int PreferenceId { get; set; }
    
    [Column("facility_type_id")]
    public int FacilityTypeId { get; set; }
}