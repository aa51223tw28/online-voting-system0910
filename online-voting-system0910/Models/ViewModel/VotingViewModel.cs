using System.ComponentModel;

namespace online_voting_system0910.Models.ViewModel
{
    public class VotingViewModel
    {
        public int VotingItemId { get; set; }
        [DisplayName("投票項目名稱")]
        public string VotingItemName { get; set; }
        [DisplayName("投票項目票數")]
        public int VotingCount { get; set; }
    }
}
