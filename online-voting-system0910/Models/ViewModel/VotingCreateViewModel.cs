namespace online_voting_system0910.Models.ViewModel
{
    public class VotingCreateViewModel
    {
        public int VotingRecordId { get; set; }
        public string Voter { get; set; }
        public List<int> SelectedVotingItems { get; set; }
    }
}
