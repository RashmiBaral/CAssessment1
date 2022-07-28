using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsAndUtility.Model
{
    public class AssessmentUserMappingVM
    {
        public int AssessmentID { get; set; }
        public List<AssessmentDetails> AssessmentInfo { get; set; }
        public List<UserDetail> UserInfo { get; set; }

    }
}
