using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class AdmissionRepo
    {
        private readonly ContextClass contextClass;

        public AdmissionRepo(ContextClass contextClass)
        {
            this.contextClass = contextClass;
        }

        public void AddNO(AdmissionNo admissionNo)
        {
            contextClass.admissionNos.Add(admissionNo);
            contextClass.SaveChanges();
        }
    }
}
