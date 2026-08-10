import { Routes } from '@angular/router';

// Auto-generated routes for the 44 Procurement pages.
// Regenerate with:  node generate-crud-routes.js

export const procurementRoutes: Routes = [
  {
    path: 'procurement/insurance-vendor',
    title: 'Insurance Vendor',
    loadComponent: () =>
      import('./insurance-vendor/insurance-vendor.component').then((m) => m.ViewInsuranceVendorComponent),
  },
  {
    path: 'procurement/insurance-vendor/new',
    title: 'New Insurance Vendor',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./insurance-vendor/insurance-vendor-form.component').then((m) => m.InsuranceVendorFormComponent),
  },
  {
    path: 'procurement/insurance-vendor/:id/edit',
    title: 'Edit Insurance Vendor',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./insurance-vendor/insurance-vendor-form.component').then((m) => m.InsuranceVendorFormComponent),
  },
  {
    path: 'procurement/inventory-item-vendor',
    title: 'Inventory Item Vendor',
    loadComponent: () =>
      import('./inventory-item-vendor/inventory-item-vendor.component').then((m) => m.ViewInventoryItemVendorComponent),
  },
  {
    path: 'procurement/inventory-item-vendor/new',
    title: 'New Inventory Item Vendor',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-vendor/inventory-item-vendor-form.component').then((m) => m.InventoryItemVendorFormComponent),
  },
  {
    path: 'procurement/inventory-item-vendor/:id/edit',
    title: 'Edit Inventory Item Vendor',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-vendor/inventory-item-vendor-form.component').then((m) => m.InventoryItemVendorFormComponent),
  },
  {
    path: 'procurement/order-line-item-status',
    title: 'Order Line Item Status',
    loadComponent: () =>
      import('./order-line-item-status/order-line-item-status.component').then((m) => m.ViewOrderLineItemStatusComponent),
  },
  {
    path: 'procurement/order-line-item-status/new',
    title: 'New Order Line Item Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./order-line-item-status/order-line-item-status-form.component').then((m) => m.OrderLineItemStatusFormComponent),
  },
  {
    path: 'procurement/order-line-item-status/:id/edit',
    title: 'Edit Order Line Item Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./order-line-item-status/order-line-item-status-form.component').then((m) => m.OrderLineItemStatusFormComponent),
  },
  {
    path: 'procurement/payment-term',
    title: 'Payment Term',
    loadComponent: () =>
      import('./payment-term/payment-term.component').then((m) => m.ViewPaymentTermComponent),
  },
  {
    path: 'procurement/payment-term/new',
    title: 'New Payment Term',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./payment-term/payment-term-form.component').then((m) => m.PaymentTermFormComponent),
  },
  {
    path: 'procurement/payment-term/:id/edit',
    title: 'Edit Payment Term',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./payment-term/payment-term-form.component').then((m) => m.PaymentTermFormComponent),
  },
  {
    path: 'procurement/poservice-asset',
    title: 'Poservice Asset',
    loadComponent: () =>
      import('./poservice-asset/poservice-asset.component').then((m) => m.ViewPoserviceAssetComponent),
  },
  {
    path: 'procurement/poservice-asset/new',
    title: 'New Poservice Asset',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./poservice-asset/poservice-asset-form.component').then((m) => m.PoserviceAssetFormComponent),
  },
  {
    path: 'procurement/poservice-asset/:id/edit',
    title: 'Edit Poservice Asset',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./poservice-asset/poservice-asset-form.component').then((m) => m.PoserviceAssetFormComponent),
  },
  {
    path: 'procurement/poservice-detail',
    title: 'Poservice Detail',
    loadComponent: () =>
      import('./poservice-detail/poservice-detail.component').then((m) => m.ViewPoserviceDetailComponent),
  },
  {
    path: 'procurement/poservice-detail/new',
    title: 'New Poservice Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./poservice-detail/poservice-detail-form.component').then((m) => m.PoserviceDetailFormComponent),
  },
  {
    path: 'procurement/poservice-detail/:id/edit',
    title: 'Edit Poservice Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./poservice-detail/poservice-detail-form.component').then((m) => m.PoserviceDetailFormComponent),
  },
  {
    path: 'procurement/poservice-outsource',
    title: 'Poservice Outsource',
    loadComponent: () =>
      import('./poservice-outsource/poservice-outsource.component').then((m) => m.ViewPoserviceOutsourceComponent),
  },
  {
    path: 'procurement/poservice-outsource/new',
    title: 'New Poservice Outsource',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./poservice-outsource/poservice-outsource-form.component').then((m) => m.PoserviceOutsourceFormComponent),
  },
  {
    path: 'procurement/poservice-outsource/:id/edit',
    title: 'Edit Poservice Outsource',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./poservice-outsource/poservice-outsource-form.component').then((m) => m.PoserviceOutsourceFormComponent),
  },
  {
    path: 'procurement/poservice-recomended-resource',
    title: 'Poservice Recomended Resource',
    loadComponent: () =>
      import('./poservice-recomended-resource/poservice-recomended-resource.component').then((m) => m.ViewPoserviceRecomendedResourceComponent),
  },
  {
    path: 'procurement/poservice-recomended-resource/new',
    title: 'New Poservice Recomended Resource',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./poservice-recomended-resource/poservice-recomended-resource-form.component').then((m) => m.PoserviceRecomendedResourceFormComponent),
  },
  {
    path: 'procurement/poservice-recomended-resource/:id/edit',
    title: 'Edit Poservice Recomended Resource',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./poservice-recomended-resource/poservice-recomended-resource-form.component').then((m) => m.PoserviceRecomendedResourceFormComponent),
  },
  {
    path: 'procurement/poservice-terms-and-condition',
    title: 'Poservice Terms And Condition',
    loadComponent: () =>
      import('./poservice-terms-and-condition/poservice-terms-and-condition.component').then((m) => m.ViewPoserviceTermsAndConditionComponent),
  },
  {
    path: 'procurement/poservice-terms-and-condition/new',
    title: 'New Poservice Terms And Condition',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./poservice-terms-and-condition/poservice-terms-and-condition-form.component').then((m) => m.PoserviceTermsAndConditionFormComponent),
  },
  {
    path: 'procurement/poservice-terms-and-condition/:id/edit',
    title: 'Edit Poservice Terms And Condition',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./poservice-terms-and-condition/poservice-terms-and-condition-form.component').then((m) => m.PoserviceTermsAndConditionFormComponent),
  },
  {
    path: 'procurement/poservice-type',
    title: 'Poservice Type',
    loadComponent: () =>
      import('./poservice-type/poservice-type.component').then((m) => m.ViewPoserviceTypeComponent),
  },
  {
    path: 'procurement/poservice-type/new',
    title: 'New Poservice Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./poservice-type/poservice-type-form.component').then((m) => m.PoserviceTypeFormComponent),
  },
  {
    path: 'procurement/poservice-type/:id/edit',
    title: 'Edit Poservice Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./poservice-type/poservice-type-form.component').then((m) => m.PoserviceTypeFormComponent),
  },
  {
    path: 'procurement/purchase-order-service',
    title: 'Purchase Order Service',
    loadComponent: () =>
      import('./purchase-order-service/purchase-order-service.component').then((m) => m.ViewPurchaseOrderServiceComponent),
  },
  {
    path: 'procurement/purchase-order-service/new',
    title: 'New Purchase Order Service',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./purchase-order-service/purchase-order-service-form.component').then((m) => m.PurchaseOrderServiceFormComponent),
  },
  {
    path: 'procurement/purchase-order-service/:id/edit',
    title: 'Edit Purchase Order Service',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./purchase-order-service/purchase-order-service-form.component').then((m) => m.PurchaseOrderServiceFormComponent),
  },
  {
    path: 'procurement/purchase-order-service-attachment',
    title: 'Purchase Order Service Attachment',
    loadComponent: () =>
      import('./purchase-order-service-attachment/purchase-order-service-attachment.component').then((m) => m.ViewPurchaseOrderServiceAttachmentComponent),
  },
  {
    path: 'procurement/purchase-order-service-attachment/new',
    title: 'New Purchase Order Service Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./purchase-order-service-attachment/purchase-order-service-attachment-form.component').then((m) => m.PurchaseOrderServiceAttachmentFormComponent),
  },
  {
    path: 'procurement/purchase-order-service-attachment/:id/edit',
    title: 'Edit Purchase Order Service Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./purchase-order-service-attachment/purchase-order-service-attachment-form.component').then((m) => m.PurchaseOrderServiceAttachmentFormComponent),
  },
  {
    path: 'procurement/request-line-item-status',
    title: 'Request Line Item Status',
    loadComponent: () =>
      import('./request-line-item-status/request-line-item-status.component').then((m) => m.ViewRequestLineItemStatusComponent),
  },
  {
    path: 'procurement/request-line-item-status/new',
    title: 'New Request Line Item Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./request-line-item-status/request-line-item-status-form.component').then((m) => m.RequestLineItemStatusFormComponent),
  },
  {
    path: 'procurement/request-line-item-status/:id/edit',
    title: 'Edit Request Line Item Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./request-line-item-status/request-line-item-status-form.component').then((m) => m.RequestLineItemStatusFormComponent),
  },
  {
    path: 'procurement/terms-and-condition',
    title: 'Terms And Condition',
    loadComponent: () =>
      import('./terms-and-condition/terms-and-condition.component').then((m) => m.ViewTermsAndConditionComponent),
  },
  {
    path: 'procurement/terms-and-condition/new',
    title: 'New Terms And Condition',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./terms-and-condition/terms-and-condition-form.component').then((m) => m.TermsAndConditionFormComponent),
  },
  {
    path: 'procurement/terms-and-condition/:id/edit',
    title: 'Edit Terms And Condition',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./terms-and-condition/terms-and-condition-form.component').then((m) => m.TermsAndConditionFormComponent),
  },
  {
    path: 'procurement/vendor',
    title: 'Vendor',
    loadComponent: () =>
      import('./vendor/vendor.component').then((m) => m.ViewVendorComponent),
  },
  {
    path: 'procurement/vendor/new',
    title: 'New Vendor',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor/vendor-form.component').then((m) => m.VendorFormComponent),
  },
  {
    path: 'procurement/vendor/:id/edit',
    title: 'Edit Vendor',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor/vendor-form.component').then((m) => m.VendorFormComponent),
  },
  {
    path: 'procurement/vendor-evaluation-criterion',
    title: 'Vendor Evaluation Criterion',
    loadComponent: () =>
      import('./vendor-evaluation-criterion/vendor-evaluation-criterion.component').then((m) => m.ViewVendorEvaluationCriterionComponent),
  },
  {
    path: 'procurement/vendor-evaluation-criterion/new',
    title: 'New Vendor Evaluation Criterion',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-evaluation-criterion/vendor-evaluation-criterion-form.component').then((m) => m.VendorEvaluationCriterionFormComponent),
  },
  {
    path: 'procurement/vendor-evaluation-criterion/:id/edit',
    title: 'Edit Vendor Evaluation Criterion',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-evaluation-criterion/vendor-evaluation-criterion-form.component').then((m) => m.VendorEvaluationCriterionFormComponent),
  },
  {
    path: 'procurement/vendor-order',
    title: 'Vendor Order',
    loadComponent: () =>
      import('./vendor-order/vendor-order.component').then((m) => m.ViewVendorOrderComponent),
  },
  {
    path: 'procurement/vendor-order/new',
    title: 'New Vendor Order',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order/vendor-order-form.component').then((m) => m.VendorOrderFormComponent),
  },
  {
    path: 'procurement/vendor-order/:id/edit',
    title: 'Edit Vendor Order',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order/vendor-order-form.component').then((m) => m.VendorOrderFormComponent),
  },
  {
    path: 'procurement/vendor-order-attachment',
    title: 'Vendor Order Attachment',
    loadComponent: () =>
      import('./vendor-order-attachment/vendor-order-attachment.component').then((m) => m.ViewVendorOrderAttachmentComponent),
  },
  {
    path: 'procurement/vendor-order-attachment/new',
    title: 'New Vendor Order Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-attachment/vendor-order-attachment-form.component').then((m) => m.VendorOrderAttachmentFormComponent),
  },
  {
    path: 'procurement/vendor-order-attachment/:id/edit',
    title: 'Edit Vendor Order Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-attachment/vendor-order-attachment-form.component').then((m) => m.VendorOrderAttachmentFormComponent),
  },
  {
    path: 'procurement/vendor-order-detail',
    title: 'Vendor Order Detail',
    loadComponent: () =>
      import('./vendor-order-detail/vendor-order-detail.component').then((m) => m.ViewVendorOrderDetailComponent),
  },
  {
    path: 'procurement/vendor-order-detail/new',
    title: 'New Vendor Order Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-detail/vendor-order-detail-form.component').then((m) => m.VendorOrderDetailFormComponent),
  },
  {
    path: 'procurement/vendor-order-detail/:id/edit',
    title: 'Edit Vendor Order Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-detail/vendor-order-detail-form.component').then((m) => m.VendorOrderDetailFormComponent),
  },
  {
    path: 'procurement/vendor-order-partially-received-note',
    title: 'Vendor Order Partially Received Note',
    loadComponent: () =>
      import('./vendor-order-partially-received-note/vendor-order-partially-received-note.component').then((m) => m.ViewVendorOrderPartiallyReceivedNoteComponent),
  },
  {
    path: 'procurement/vendor-order-partially-received-note/new',
    title: 'New Vendor Order Partially Received Note',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-partially-received-note/vendor-order-partially-received-note-form.component').then((m) => m.VendorOrderPartiallyReceivedNoteFormComponent),
  },
  {
    path: 'procurement/vendor-order-partially-received-note/:id/edit',
    title: 'Edit Vendor Order Partially Received Note',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-partially-received-note/vendor-order-partially-received-note-form.component').then((m) => m.VendorOrderPartiallyReceivedNoteFormComponent),
  },
  {
    path: 'procurement/vendor-order-quality',
    title: 'Vendor Order Quality',
    loadComponent: () =>
      import('./vendor-order-quality/vendor-order-quality.component').then((m) => m.ViewVendorOrderQualityComponent),
  },
  {
    path: 'procurement/vendor-order-quality/new',
    title: 'New Vendor Order Quality',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-quality/vendor-order-quality-form.component').then((m) => m.VendorOrderQualityFormComponent),
  },
  {
    path: 'procurement/vendor-order-quality/:id/edit',
    title: 'Edit Vendor Order Quality',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-quality/vendor-order-quality-form.component').then((m) => m.VendorOrderQualityFormComponent),
  },
  {
    path: 'procurement/vendor-order-quality-attachment',
    title: 'Vendor Order Quality Attachment',
    loadComponent: () =>
      import('./vendor-order-quality-attachment/vendor-order-quality-attachment.component').then((m) => m.ViewVendorOrderQualityAttachmentComponent),
  },
  {
    path: 'procurement/vendor-order-quality-attachment/new',
    title: 'New Vendor Order Quality Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-quality-attachment/vendor-order-quality-attachment-form.component').then((m) => m.VendorOrderQualityAttachmentFormComponent),
  },
  {
    path: 'procurement/vendor-order-quality-attachment/:id/edit',
    title: 'Edit Vendor Order Quality Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-quality-attachment/vendor-order-quality-attachment-form.component').then((m) => m.VendorOrderQualityAttachmentFormComponent),
  },
  {
    path: 'procurement/vendor-order-quality-detail',
    title: 'Vendor Order Quality Detail',
    loadComponent: () =>
      import('./vendor-order-quality-detail/vendor-order-quality-detail.component').then((m) => m.ViewVendorOrderQualityDetailComponent),
  },
  {
    path: 'procurement/vendor-order-quality-detail/new',
    title: 'New Vendor Order Quality Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-quality-detail/vendor-order-quality-detail-form.component').then((m) => m.VendorOrderQualityDetailFormComponent),
  },
  {
    path: 'procurement/vendor-order-quality-detail/:id/edit',
    title: 'Edit Vendor Order Quality Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-quality-detail/vendor-order-quality-detail-form.component').then((m) => m.VendorOrderQualityDetailFormComponent),
  },
  {
    path: 'procurement/vendor-order-quality-detail-batch',
    title: 'Vendor Order Quality Detail Batch',
    loadComponent: () =>
      import('./vendor-order-quality-detail-batch/vendor-order-quality-detail-batch.component').then((m) => m.ViewVendorOrderQualityDetailBatchComponent),
  },
  {
    path: 'procurement/vendor-order-quality-detail-batch/new',
    title: 'New Vendor Order Quality Detail Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-quality-detail-batch/vendor-order-quality-detail-batch-form.component').then((m) => m.VendorOrderQualityDetailBatchFormComponent),
  },
  {
    path: 'procurement/vendor-order-quality-detail-batch/:id/edit',
    title: 'Edit Vendor Order Quality Detail Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-quality-detail-batch/vendor-order-quality-detail-batch-form.component').then((m) => m.VendorOrderQualityDetailBatchFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive',
    title: 'Vendor Order Receive',
    loadComponent: () =>
      import('./vendor-order-receive/vendor-order-receive.component').then((m) => m.ViewVendorOrderReceiveComponent),
  },
  {
    path: 'procurement/vendor-order-receive/new',
    title: 'New Vendor Order Receive',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-receive/vendor-order-receive-form.component').then((m) => m.VendorOrderReceiveFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive/:id/edit',
    title: 'Edit Vendor Order Receive',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-receive/vendor-order-receive-form.component').then((m) => m.VendorOrderReceiveFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-attachment',
    title: 'Vendor Order Receive Attachment',
    loadComponent: () =>
      import('./vendor-order-receive-attachment/vendor-order-receive-attachment.component').then((m) => m.ViewVendorOrderReceiveAttachmentComponent),
  },
  {
    path: 'procurement/vendor-order-receive-attachment/new',
    title: 'New Vendor Order Receive Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-receive-attachment/vendor-order-receive-attachment-form.component').then((m) => m.VendorOrderReceiveAttachmentFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-attachment/:id/edit',
    title: 'Edit Vendor Order Receive Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-receive-attachment/vendor-order-receive-attachment-form.component').then((m) => m.VendorOrderReceiveAttachmentFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail',
    title: 'Vendor Order Receive Detail',
    loadComponent: () =>
      import('./vendor-order-receive-detail/vendor-order-receive-detail.component').then((m) => m.ViewVendorOrderReceiveDetailComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail/new',
    title: 'New Vendor Order Receive Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-receive-detail/vendor-order-receive-detail-form.component').then((m) => m.VendorOrderReceiveDetailFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail/:id/edit',
    title: 'Edit Vendor Order Receive Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-receive-detail/vendor-order-receive-detail-form.component').then((m) => m.VendorOrderReceiveDetailFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail-batch',
    title: 'Vendor Order Receive Detail Batch',
    loadComponent: () =>
      import('./vendor-order-receive-detail-batch/vendor-order-receive-detail-batch.component').then((m) => m.ViewVendorOrderReceiveDetailBatchComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail-batch/new',
    title: 'New Vendor Order Receive Detail Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-receive-detail-batch/vendor-order-receive-detail-batch-form.component').then((m) => m.VendorOrderReceiveDetailBatchFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail-batch/:id/edit',
    title: 'Edit Vendor Order Receive Detail Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-receive-detail-batch/vendor-order-receive-detail-batch-form.component').then((m) => m.VendorOrderReceiveDetailBatchFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail-batch-serial',
    title: 'Vendor Order Receive Detail Batch Serial',
    loadComponent: () =>
      import('./vendor-order-receive-detail-batch-serial/vendor-order-receive-detail-batch-serial.component').then((m) => m.ViewVendorOrderReceiveDetailBatchSerialComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail-batch-serial/new',
    title: 'New Vendor Order Receive Detail Batch Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-receive-detail-batch-serial/vendor-order-receive-detail-batch-serial-form.component').then((m) => m.VendorOrderReceiveDetailBatchSerialFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-detail-batch-serial/:id/edit',
    title: 'Edit Vendor Order Receive Detail Batch Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-receive-detail-batch-serial/vendor-order-receive-detail-batch-serial-form.component').then((m) => m.VendorOrderReceiveDetailBatchSerialFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-serial',
    title: 'Vendor Order Receive Serial',
    loadComponent: () =>
      import('./vendor-order-receive-serial/vendor-order-receive-serial.component').then((m) => m.ViewVendorOrderReceiveSerialComponent),
  },
  {
    path: 'procurement/vendor-order-receive-serial/new',
    title: 'New Vendor Order Receive Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-receive-serial/vendor-order-receive-serial-form.component').then((m) => m.VendorOrderReceiveSerialFormComponent),
  },
  {
    path: 'procurement/vendor-order-receive-serial/:id/edit',
    title: 'Edit Vendor Order Receive Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-receive-serial/vendor-order-receive-serial-form.component').then((m) => m.VendorOrderReceiveSerialFormComponent),
  },
  {
    path: 'procurement/vendor-order-screen',
    title: 'Vendor Order Screen',
    loadComponent: () =>
      import('./vendor-order-screen/vendor-order-screen.component').then((m) => m.ViewVendorOrderScreenComponent),
  },
  {
    path: 'procurement/vendor-order-screen/new',
    title: 'New Vendor Order Screen',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-screen/vendor-order-screen-form.component').then((m) => m.VendorOrderScreenFormComponent),
  },
  {
    path: 'procurement/vendor-order-screen/:id/edit',
    title: 'Edit Vendor Order Screen',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-screen/vendor-order-screen-form.component').then((m) => m.VendorOrderScreenFormComponent),
  },
  {
    path: 'procurement/vendor-order-status',
    title: 'Vendor Order Status',
    loadComponent: () =>
      import('./vendor-order-status/vendor-order-status.component').then((m) => m.ViewVendorOrderStatusComponent),
  },
  {
    path: 'procurement/vendor-order-status/new',
    title: 'New Vendor Order Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-status/vendor-order-status-form.component').then((m) => m.VendorOrderStatusFormComponent),
  },
  {
    path: 'procurement/vendor-order-status/:id/edit',
    title: 'Edit Vendor Order Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-status/vendor-order-status-form.component').then((m) => m.VendorOrderStatusFormComponent),
  },
  {
    path: 'procurement/vendor-order-type',
    title: 'Vendor Order Type',
    loadComponent: () =>
      import('./vendor-order-type/vendor-order-type.component').then((m) => m.ViewVendorOrderTypeComponent),
  },
  {
    path: 'procurement/vendor-order-type/new',
    title: 'New Vendor Order Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-type/vendor-order-type-form.component').then((m) => m.VendorOrderTypeFormComponent),
  },
  {
    path: 'procurement/vendor-order-type/:id/edit',
    title: 'Edit Vendor Order Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-type/vendor-order-type-form.component').then((m) => m.VendorOrderTypeFormComponent),
  },
  {
    path: 'procurement/vendor-order-vendor-selection',
    title: 'Vendor Order Vendor Selection',
    loadComponent: () =>
      import('./vendor-order-vendor-selection/vendor-order-vendor-selection.component').then((m) => m.ViewVendorOrderVendorSelectionComponent),
  },
  {
    path: 'procurement/vendor-order-vendor-selection/new',
    title: 'New Vendor Order Vendor Selection',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-vendor-selection/vendor-order-vendor-selection-form.component').then((m) => m.VendorOrderVendorSelectionFormComponent),
  },
  {
    path: 'procurement/vendor-order-vendor-selection/:id/edit',
    title: 'Edit Vendor Order Vendor Selection',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-vendor-selection/vendor-order-vendor-selection-form.component').then((m) => m.VendorOrderVendorSelectionFormComponent),
  },
  {
    path: 'procurement/vendor-order-vendor-suggested',
    title: 'Vendor Order Vendor Suggested',
    loadComponent: () =>
      import('./vendor-order-vendor-suggested/vendor-order-vendor-suggested.component').then((m) => m.ViewVendorOrderVendorSuggestedComponent),
  },
  {
    path: 'procurement/vendor-order-vendor-suggested/new',
    title: 'New Vendor Order Vendor Suggested',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-order-vendor-suggested/vendor-order-vendor-suggested-form.component').then((m) => m.VendorOrderVendorSuggestedFormComponent),
  },
  {
    path: 'procurement/vendor-order-vendor-suggested/:id/edit',
    title: 'Edit Vendor Order Vendor Suggested',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-order-vendor-suggested/vendor-order-vendor-suggested-form.component').then((m) => m.VendorOrderVendorSuggestedFormComponent),
  },
  {
    path: 'procurement/vendor-return',
    title: 'Vendor Return',
    loadComponent: () =>
      import('./vendor-return/vendor-return.component').then((m) => m.ViewVendorReturnComponent),
  },
  {
    path: 'procurement/vendor-return/new',
    title: 'New Vendor Return',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-return/vendor-return-form.component').then((m) => m.VendorReturnFormComponent),
  },
  {
    path: 'procurement/vendor-return/:id/edit',
    title: 'Edit Vendor Return',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-return/vendor-return-form.component').then((m) => m.VendorReturnFormComponent),
  },
  {
    path: 'procurement/vendor-return-attachment',
    title: 'Vendor Return Attachment',
    loadComponent: () =>
      import('./vendor-return-attachment/vendor-return-attachment.component').then((m) => m.ViewVendorReturnAttachmentComponent),
  },
  {
    path: 'procurement/vendor-return-attachment/new',
    title: 'New Vendor Return Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-return-attachment/vendor-return-attachment-form.component').then((m) => m.VendorReturnAttachmentFormComponent),
  },
  {
    path: 'procurement/vendor-return-attachment/:id/edit',
    title: 'Edit Vendor Return Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-return-attachment/vendor-return-attachment-form.component').then((m) => m.VendorReturnAttachmentFormComponent),
  },
  {
    path: 'procurement/vendor-return-detail',
    title: 'Vendor Return Detail',
    loadComponent: () =>
      import('./vendor-return-detail/vendor-return-detail.component').then((m) => m.ViewVendorReturnDetailComponent),
  },
  {
    path: 'procurement/vendor-return-detail/new',
    title: 'New Vendor Return Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-return-detail/vendor-return-detail-form.component').then((m) => m.VendorReturnDetailFormComponent),
  },
  {
    path: 'procurement/vendor-return-detail/:id/edit',
    title: 'Edit Vendor Return Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-return-detail/vendor-return-detail-form.component').then((m) => m.VendorReturnDetailFormComponent),
  },
  {
    path: 'procurement/vendor-return-detail-batch',
    title: 'Vendor Return Detail Batch',
    loadComponent: () =>
      import('./vendor-return-detail-batch/vendor-return-detail-batch.component').then((m) => m.ViewVendorReturnDetailBatchComponent),
  },
  {
    path: 'procurement/vendor-return-detail-batch/new',
    title: 'New Vendor Return Detail Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-return-detail-batch/vendor-return-detail-batch-form.component').then((m) => m.VendorReturnDetailBatchFormComponent),
  },
  {
    path: 'procurement/vendor-return-detail-batch/:id/edit',
    title: 'Edit Vendor Return Detail Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-return-detail-batch/vendor-return-detail-batch-form.component').then((m) => m.VendorReturnDetailBatchFormComponent),
  },
  {
    path: 'procurement/vendor-return-detail-batch-serial',
    title: 'Vendor Return Detail Batch Serial',
    loadComponent: () =>
      import('./vendor-return-detail-batch-serial/vendor-return-detail-batch-serial.component').then((m) => m.ViewVendorReturnDetailBatchSerialComponent),
  },
  {
    path: 'procurement/vendor-return-detail-batch-serial/new',
    title: 'New Vendor Return Detail Batch Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-return-detail-batch-serial/vendor-return-detail-batch-serial-form.component').then((m) => m.VendorReturnDetailBatchSerialFormComponent),
  },
  {
    path: 'procurement/vendor-return-detail-batch-serial/:id/edit',
    title: 'Edit Vendor Return Detail Batch Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-return-detail-batch-serial/vendor-return-detail-batch-serial-form.component').then((m) => m.VendorReturnDetailBatchSerialFormComponent),
  },
  {
    path: 'procurement/vendor-return-serial',
    title: 'Vendor Return Serial',
    loadComponent: () =>
      import('./vendor-return-serial/vendor-return-serial.component').then((m) => m.ViewVendorReturnSerialComponent),
  },
  {
    path: 'procurement/vendor-return-serial/new',
    title: 'New Vendor Return Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-return-serial/vendor-return-serial-form.component').then((m) => m.VendorReturnSerialFormComponent),
  },
  {
    path: 'procurement/vendor-return-serial/:id/edit',
    title: 'Edit Vendor Return Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-return-serial/vendor-return-serial-form.component').then((m) => m.VendorReturnSerialFormComponent),
  },
  {
    path: 'procurement/vendor-specialization',
    title: 'Vendor Specialization',
    loadComponent: () =>
      import('./vendor-specialization/vendor-specialization.component').then((m) => m.ViewVendorSpecializationComponent),
  },
  {
    path: 'procurement/vendor-specialization/new',
    title: 'New Vendor Specialization',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-specialization/vendor-specialization-form.component').then((m) => m.VendorSpecializationFormComponent),
  },
  {
    path: 'procurement/vendor-specialization/:id/edit',
    title: 'Edit Vendor Specialization',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-specialization/vendor-specialization-form.component').then((m) => m.VendorSpecializationFormComponent),
  },
  {
    path: 'procurement/vendor-status',
    title: 'Vendor Status',
    loadComponent: () =>
      import('./vendor-status/vendor-status.component').then((m) => m.ViewVendorStatusComponent),
  },
  {
    path: 'procurement/vendor-status/new',
    title: 'New Vendor Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-status/vendor-status-form.component').then((m) => m.VendorStatusFormComponent),
  },
  {
    path: 'procurement/vendor-status/:id/edit',
    title: 'Edit Vendor Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-status/vendor-status-form.component').then((m) => m.VendorStatusFormComponent),
  },
  {
    path: 'procurement/vendor-type',
    title: 'Vendor Type',
    loadComponent: () =>
      import('./vendor-type/vendor-type.component').then((m) => m.ViewVendorTypeComponent),
  },
  {
    path: 'procurement/vendor-type/new',
    title: 'New Vendor Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vendor-type/vendor-type-form.component').then((m) => m.VendorTypeFormComponent),
  },
  {
    path: 'procurement/vendor-type/:id/edit',
    title: 'Edit Vendor Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vendor-type/vendor-type-form.component').then((m) => m.VendorTypeFormComponent),
  },
];
