using LearnerRater.Tests.Models;

namespace LearnerRater.Tests.Contexts
{
    public class ResourcePageContext
    {
        public Resource Resource { get; set; }
        public int NumberOfResourcesBeforeAdd { get; set; }
        public int NumberOfReviewsBeforeAdd { get; set; }
    }
}
