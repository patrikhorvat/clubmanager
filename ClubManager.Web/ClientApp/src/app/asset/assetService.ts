import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/core/http/api.service';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class AssetService {

  constructor(private apiService: ApiService) { }

  get(id: number) {
    return this.apiService.get("/asset/" + id);
  }
  createAsset(model: any) {
    return this.apiService.post("/asset/create", model);
  }
  changeStatus(id: number, statusId: number) {
    return this.apiService.patch(`/asset/${id}/status/${statusId}`);
  }
  updateAsset(model: any) {
    return this.apiService.put("/asset/update", model);
  }

  getAssetTypes() {
    return this.apiService.get("/asset/types");
  }

  deleteAsset(id: number) {
    return this.apiService.delete("/asset/" + id);
  }

}

