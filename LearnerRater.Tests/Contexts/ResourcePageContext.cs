using LearnerRater.Tests.Models;

namespace LearnerRater.Tests.Contexts
{
    public class ResourcePageContext
    {
        public Resource Resource { get; set; }
        public int NumberOfResourcesBeforeAction { get; set; }
        public int NumberOfReviewsBeforeAction { get; set; }
    }
}
