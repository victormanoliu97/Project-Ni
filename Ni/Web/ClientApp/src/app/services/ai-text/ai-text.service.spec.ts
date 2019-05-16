import { TestBed, inject } from '@angular/core/testing';

import { AiTextService } from './ai-text.service';

describe('AiTextService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AiTextService]
    });
  });

  it('should be created', inject([AiTextService], (service: AiTextService) => {
    expect(service).toBeTruthy();
  }));
});
