import { TestBed } from '@angular/core/testing';

import { OrderItemService } from './orderitem.service';

describe('OrderitemService', () => {
  let service: OrderItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
