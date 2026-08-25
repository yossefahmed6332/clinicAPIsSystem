using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.IRepositoryService
{
    public interface IPaymentOperationRepository
    {
        public Task<PaymentOperation> ICreatePaymentOperationAsync();
        public Task<List<PaymentOperation>> IGetAllPaymentOperationsAsync();
        public Task<PaymentOperation> IGetPaymentOperationAsync(int id);
        public Task<List<PaymentOperation>> IGetPaymentOperationsByPatientIdAsync(int patientId);
        public Task<List<PaymentOperation>> IGetPaymentOperationsByAccountantIdAsync(int accountantId);
        public Task<PaymentOperation> IUpdatePaymentOperationAsync(PaymentOperation paymentOperation);
        public Task IDeletePaymentOperationAsync(int id);
    }
}
