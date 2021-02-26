
<template>
  <div class="dialog"  >
      <div class="dialog-bg"></div>
      <div class="m-dialog dialog-detail" title="Thông tin nhân viên" >
        
        <div class="dialog-content">
            <div class="dialog-title">
                <span class="headline">{{openDialog.status}}</span>
                <span class="icon-close"  @click="dlg_close()"></span>
            </div>
            
            <div class="dialog-body">
                

                  

               <div class="m-row  ">
                <div class="m-col m-flex">
                    <div class="m-label mg-top-5px" >Mã cửa hàng (<span class="label-required">*</span>)</div>
                    <div  class="m-control input mg-left-10px " >
                      <input ref="code" v-model="storeInfo.StoreCode"  required 
                      @blur="validateData('StoreCode')"
                      :class="{'error-required': !validate.StoreCode}" type="text" placeholder="Trường bắt buộc nhập" />
                    </div>
                </div>
                
            </div>
            <div class="m-row  ">
                
                <div class="m-flex" >
                    <div class="m-label mg-top-5px">Tên cửa hàng (<span class="label-required">*</span>)</div>
                    <div class="m-control input mg-left-10px" >
                        <input v-model="storeInfo.StoreName" placeholder="Trường bắt buộc nhập"  class="input-required" type="text" required 
                          @blur="validateData('StoreName')"
                          :class="{'error-required': !validate.StoreName}" />
                    </div>
                </div>
            </div>
            
            <div class="m-row  ">
                
                <div class="m-flex" >
                    <div class="m-label mg-top-5px">Địa chỉ (<span class="label-required">*</span>)</div>
                    <div class="m-control input mg-left-10px" >
                        <input v-model="storeInfo.Address" class="input-required" type="text" required 
                        @blur="validateData('Address')"
                        :class="{'error-required': !validate.Address}" placeholder="Trường bắt buộc nhập"/>
                        
                    </div>
                </div>
                
            </div>
            <div class="m-row m-flex ">
                
                <div class=" detail m-flex dlg-left" >
                    <div class="m-label mg-top-5px" >Số điện thoại </div>
                    <div class="m-control input-select mg-left-10px" >
                       <input type="text" v-model="storeInfo.PhoneNumber">
                    </div>
                </div>
                <div class=" detail m-flex dlg-right" >
                    <div class="m-label mg-top-5px">Mã số thuế</div>
                    <div class="m-control input-select mg-left-10px" >
                        <input type="text" v-model="storeInfo.TaxCode">
                    </div>
                </div>
            </div>
            <div class="m-row m-flex ">
                
                <div class=" detail m-flex dlg-left" >
                    <div class="m-label mg-top-5px" >Quốc gia </div>
                    <div class="m-control input-select mg-left-10px" >
                       <select name="" id="">
                         <option value="">Việt Nam</option>
                       </select>
                    </div>
                </div>
              
            </div>
            <div class=" m-row m-flex  ">
                <div class=" detail m-flex dlg-left" >
                    <div class="m-label mg-top-5px" >Tỉnh/Thành phố </div>
                    <div class="m-control input-select mg-left-10px" >
                       <select @change="filterDistrict()" v-model="ProvinceId_">
                                    <option value="" disabled selected>Tỉnh/Thành phố</option>
                                    <option v-for="(data,index) in ProvinceData" :key="index" :value="data.ProvinceId">{{data.ProvinceName}}</option>
                                  
                                  
                        </select>
                    </div>
                </div>
                <div class=" detail m-flex dlg-right" >
                    <div class="m-label mg-top-5px">Huyện/Quận </div>
                    <div class="m-control input-select mg-left-10px" >
                        <select @change="filterWard()" v-model="DistrictId_">
                                    <option value="" disabled selected>Quận/Huyện</option>
                                    <option v-for="(data,index) in DistrictData" :key="index" :value="data.DistrictId">{{data.DistrictName}}</option>
                                    
                        </select>
                    </div>
                </div>

            </div>
            <div class="m-row m-flex ">
                
                <div class=" detail m-flex dlg-left" >
                    <div class="m-label mg-top-5px">Xã/Phường </div>
                    <div class="m-control input-select mg-left-10px" >
                        <select v-model="WardId_">
                                    <option value="" disabled selected>Xã/Phường</option>
                                    <option v-for="(data,index) in WardData" :key="index" :value="data.WardId">{{data.WardName}}</option>
                                    
                        </select>
                    </div>
                </div>

                <div class=" detail m-flex dlg-right" >
                    <div class="m-label mg-top-5px">Đường phố</div>
                    <div class="m-control input-select mg-left-10px " >
                        <input type="text" v-model="storeInfo.Street">
                    </div>
                </div>
            </div>
           
            
            



            </div>
            
            <div class="dialog-footer">
                <button  class="m-btn m-btn-default b-save" @click="save()"><span class="i-save"></span><span  class="btn-text save">Lưu</span></button>
                <button  class="m-btn m-btn-default b-save" @click="saveAdd()" style="background-color: white; width: auto; border: 1px solid #005577"><span class="i-save"></span><span style="padding: 5px; color: #00577b" class="btn-text save">Lưu và thêm mới</span></button>
                
                <button  class="m-btn m-btn-default b-cancel" @click="dlg_close()"><span class="i-cancel"></span><span  class="btn-text cancel">Hủy</span></button>
                
            </div>
        </div>
    </div>
    
  </div>
</template>

<script>
  import axios from 'axios'
  export default {
    props:{
        focusData: Object,
        openDialog: Object
        
    },
    data: () => ({
        storeInfo:{
            StoreCode: null,
            StoreName: null,
            Address: null,
            PhoneNumber: null,
            WardId: null,
            TaxCode: null,
            Street:null,
            ProvinceId:null,
            DistrictId:null,
            
        },
        ProvinceId_:"",
        ProvinceName:null,
        DistrictId_:"",
        WardId_:"",
        DistrictName:null,
        ProvinceData:null,
        DistrictData:null,
        WardData:null,
        add:true,
        validate: {
            StoreCode: true,
            StoreName: true,
            Address: true,
        }
    }),
    mounted() {
      //focus vào dòng đầu tiên
       this.$refs.code.focus();
      
      //check nếu sửa thì load dữ liệu
       if(this.focusData.StoreId!=null&&this.openDialog.status == "Sửa thông tin cửa hàng"){
            this.add = false;
            
                    for( var _item in this.storeInfo){
                      
                        var item = _item.toString();
                        this.storeInfo[item] = this.focusData[item];
                    }
                    this.ProvinceId_ = this.focusData.ProvinceId;
                    this.DistrictId_ = this.focusData.DistrictId;
                    this.WardId_ = this.focusData.WardId;
           

            axios.get('https://localhost:44384/api/Provinces/')
            .then(response => {
               
                    
                    this.ProvinceData = response.data;
            })
            .catch(error => console.log(error))
            axios.get('https://localhost:44384/api/Districts/')
            .then(response => {
               
                    
                    this.DistrictData = response.data;
            })
            .catch(error => console.log(error))
            axios.get('https://localhost:44384/api/Wards/')
            .then(response => {
               
                    
                    this.WardData = response.data;
            })
            .catch(error => console.log(error))

        }
        //nếu là thêm mới thì load dữ liệu các tỉnh
        else {
          this.add = true;
          axios.get('https://localhost:44384/api/Provinces/')
            .then(response => {
               
                    
                    this.ProvinceData = response.data;
            })
            .catch(error => console.log(error))
          
        }
        
        
    },
    methods: {
      //validate dữ liệu nhập trống
      validateData(key) {
        if (this.storeInfo[key] === null || this.storeInfo[key] === "") {
          this.validate[key] = false;
        } else {
          this.validate[key] = true;
        }
      },
      //đóng dialog
      dlg_close(){
          
          this.$emit('close');
      },
      //lưu lại sửa hoặc thêm
      save(){
        this.storeInfo.ProvinceId = this.ProvinceId_;
        this.storeInfo.DistrictId = this.DistrictId_;
        this.storeInfo.WardId = this.WardId_;
        
        if(this.focusData.StoreId && this.openDialog.status == "Sửa thông tin cửa hàng"){
            
              
              axios.put("https://localhost:44384/api/Stores/"+this.focusData.StoreId,this.storeInfo)
                  .then(() => {
                      
                      this.$emit('success');                                           
                      
                      
                  })
                  .catch(error => this.$emit('error',error.response.data.Messenger))
          }
          else{
              
              
              axios.post("https://localhost:44384/api/Stores/",this.storeInfo)
                  .then((res) => {
                      
                      this.$emit('success');
                      console.log(res);
                      
                  })
                  .catch(errors => {this.$emit('error',errors.response.data.Messenger)})
                  
          }
      },
      //lưu và thêm mới
      saveAdd(){
        this.storeInfo.ProvinceId = this.ProvinceId_;
        this.storeInfo.DistrictId = this.DistrictId_;
        this.storeInfo.WardId = this.WardId_;
        
        if(this.focusData.StoreId && this.openDialog.status == "Sửa thông tin cửa hàng"){
            
              
              axios.put("https://localhost:44384/api/Stores/"+this.focusData.StoreId,this.storeInfo)
                  .then(() => {
                      
                      this.$emit('success');                                           
                      
                      
                  })
                  .catch(error => this.$emit('error',error.response.data.Messenger))
          }
          else{
              
              
              axios.post("https://localhost:44384/api/Stores/",this.storeInfo)
                  .then((res) => {
                      
                      this.$emit('success');
                      console.log(res);
                      
                  })
                  .catch(errors => {this.$emit('error',errors.response.data.Messenger)})
                  
          }
      },
      //lọc ra các huyện theo tỉnh
      filterDistrict(){
        console.log(this.ProvinceId_)
        if(this.ProvinceId_!=null){
        
          axios.get('https://localhost:44384/api/Districts/province/'+this.ProvinceId_)
          .then(response => {
              
                  
                  this.DistrictData = response.data;
          })
          .catch(error => console.log(error))
        }
      },
      //lọc ra các xã theo huyện
      filterWard(){
        console.log(this.DistrictId_)
        if(this.DistrictId_!=null){
        
          axios.get('https://localhost:44384/api/Wards/district/'+this.DistrictId_)
          .then(response => {
              
                  
                  this.WardData = response.data;
          })
          .catch(error => console.log(error))
        }
      }
        
    },
    
  }

</script>
<style scoped>
.error-required {
  border: 1px solid red !important;
}
  .input{
    width: 70%;
    position:absolute;
    right: 20px;
  }
  
 .detail{
    position: absolute;
    
    margin-left: 5px;
    width: 300px;
  }
  .detail.m-flex.dlg-left {
    left: 32px;
  }
  .detail.m-flex.dlg-right .m-label {
    padding-left: 30px;
  }
  .dlg-right{
    right: 20px;
  }
  .m-control.input-select.mg-left-10px {
    position: absolute;
    right: 0;
}
.m-control.input-select.mg-left-10px {
    width: 146px;
}
  .m-control.input-select {
    width: 120px;
}
</style>