import { TestBed, inject } from '@angular/core/testing';

import { BingService } from './bing.service';

describe('BingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BingService]
    });
  });

  it('should be created', inject([BingService], (service: BingService) => {
    expect(service).toBeTruthy();
  }));
});
