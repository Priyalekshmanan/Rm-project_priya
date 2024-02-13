using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class NotificationRepository : IRepositoty<Notification>
    {
        public readonly ContextClass contextClass;

        public NotificationRepository(ContextClass contextClass)
        {
            this.contextClass = contextClass;
        }

        public void Add(Notification entity)
        {
            /*            entity.GeneraterandomMessage();
                        entity.notificationId=Guid.NewGuid().ToString();*/
            entity.notificationId = new Random().Next(1000, 10000).ToString();
            contextClass.notification.Add(entity);
            contextClass.SaveChanges();

        }

        public void Delete(string id)
        {
            Notification notification = contextClass.notification.Find(id);
            contextClass.notification.Remove(notification);
            contextClass.SaveChanges();
        }

        public Notification Get(string id)
        {
            return contextClass.notification.Find(id);
        }

        public List<Notification> GetAll()
        {
            return contextClass.notification.ToList();
        }

        public void Update(Notification entity)
        {
            contextClass.Update(entity);
            contextClass.SaveChanges();
        }
    }
}
