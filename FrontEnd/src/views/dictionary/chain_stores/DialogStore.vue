
<template>
  <div class="dialog"  >
      <div class="dialog-bg"></div>
      <div class="m-dialog dialog-detail" title="Thông tin nhân viên" >
        
        <div class="dialog-content">
            <div class="dialog-title">
                <span class="headline">{{info.status}}</span>
                <span class="icon-close"  @click="dlg_close()"></span>
            </div>
            
            <div class="dialog-body">
                

                  

               <div class="m-row  ">
                <div class="m-col m-flex">
                    <div class="m-label mg-top-5px" >Mã cửa hàng (<span class="label-required">*</span>)</div>
                    <div  class="m-control input mg-left-10px " ><input ref="code" v-model="storeInfo.StoreCode"  required class="input-required" type="text" /></div>
                </div>
                
            </div>
            <div class="m-row  ">
                
                <div class="m-flex" >
                    <div class="m-label mg-top-5px">Tên cửa hàng (<span class="label-required">*</span>)</div>
                    <div class="m-control input mg-left-10px" >
                        <input v-model="storeInfo.StoreName"  class="input-required" type="text" required />
                    </div>
                </div>
            </div>
            
            <div class="m-row  ">
                
                <div class="m-flex" >
                    <div class="m-label mg-top-5px">Địa chỉ (<span class="label-required">*</span>)</div>
                    <div class="m-control input mg-left-10px" >
                        <input v-model="storeInfo.Address" class="input-required" type="text" required />
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
            <div class=" m-row m-flex  ">
                <div class=" detail m-flex dlg-left" >
                    <div class="m-label mg-top-5px" >Tỉnh/Thành phố </div>
                    <div class="m-control input-select mg-left-10px" >
                       <select @change="filterDistrict()" v-model="ProvinceId">
                                    <option v-for="(data,index) in ProvinceData" :key="index" :value="data.ProvinceId">{{data.ProvinceName}}</option>
                                    
                        </select>
                    </div>
                </div>
                <div class=" detail m-flex dlg-right" >
                    <div class="m-label mg-top-5px">Huyện/Quận </div>
                    <div class="m-control input-select mg-left-10px" >
                        <select @change="filterWard()" v-model="DistrictId">
                                    <option v-for="(data,index) in DistrictData" :key="index" :value="data.DistrictId">{{data.DistrictName}}</option>
                                    
                        </select>
                    </div>
                </div>

            </div>
            <div class="m-row m-flex ">
                
                <div class=" detail m-flex dlg-left" >
                    <div class="m-label mg-top-5px">Xã/Phường </div>
                    <div class="m-control input-select mg-left-10px" >
                        <select v-model="WardId">
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
                <button  class="m-btn m-btn-default b-save" @click="save()"><i class="i-save"></i><span  class="btn-text save">Lưu</span></button>
                
                <button  class="m-btn m-btn-default b-cancel" @click="dlg_close()"><i class="i-cancel"></i><span  class="btn-text cancel">Hủy</span></button>
                
            </div>
        </div>
    </div>
    
  </div>
</template>

<script>
  import axios from 'axios'
  export default {
    props:{
        info: Object,
        
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
            DistrictName:null,
            ProvinceData:null,
            DistrictData:null,
          
        },
        ProvinceId:null,
        ProvinceName:null,
        DistrictId:null,
        WardId:null,
        DistrictName:null,
        ProvinceData:null,
        DistrictData:null,
        WardData:null,
        add:true
    }),
    mounted() {
      
       this.$refs.code.focus();
      
       if(this.info.StoreId!=null&&this.info.status == "Sửa thông tin cửa hàng"){
            this.add = false;
            axios.get('https://localhost:44384/api/Stores/'+this.info.StoreId)
            .then(response => {
               
                    
                    for( var _item in this.storeInfo){
                      
                        var item = _item.toString();
                        this.storeInfo[item] = response.data[item];
                    }
                    this.ProvinceId = response.data.ProvinceId;
                    this.DistrictId = response.data.DistrictId;
                    this.WardId = response.data.WardId;
            })
            .catch(error => console.log(error))

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
        dlg_close(){
            
            this.$emit('close');
        },
        save(){
          this.storeInfo.ProvinceId = this.ProvinceId;
          this.storeInfo.DistrictId = this.DistrictId;
          this.storeInfo.WardId = this.WardId;
          if(!this.storeInfo.StoreCode){
            alert("Bạn chưa nhập Mã cửa hàng ( bắt buộc ) !");
            return;
          }
          if(!this.storeInfo.StoreName){
            alert("Bạn chưa nhập Tên cửa hàng ( bắt buộc ) !");
            return;
          }
          if(!this.storeInfo.Address){
            alert("Bạn chưa nhập Địa chỉ cửa hàng ( bắt buộc ) !");
            return;
          }
          if(this.info.StoreId && this.info.status == "Sửa thông tin cửa hàng"){
             
               
               axios.put("https://localhost:44384/api/Stores/"+this.info.StoreId,this.storeInfo)
                    .then(() => {
                       
                        alert('Sửa thành thành công!');                                             
                        this.$emit('close');
                       //eventBus.$emit('reLoad');
                    })
                    .catch(error => console.log(error.response.data.Messenger))
           }
           else{
                
               
               axios.post("https://localhost:44384/api/Stores/",this.storeInfo)
                    .then(() => {
                       
                        alert('Thêm thành công!');                                             
                        this.$emit('close');
                        //eventBus.$emit('reLoad');
                    })
                    .catch(response => console.log(response))
                    
           }
        },
        save_add(){
          this.save();
          this.$emit('save-add');
        },
        filterDistrict(){
          console.log(this.ProvinceId)
          if(this.ProvinceId!=null){
         
            axios.get('https://localhost:44384/api/Districts/province/'+this.ProvinceId)
            .then(response => {
               
                    
                    this.DistrictData = response.data;
            })
            .catch(error => console.log(error))
          }
        },
        filterWard(){
          console.log(this.DistrictId)
          if(this.DistrictId!=null){
         
            axios.get('https://localhost:44384/api/Wards/district/'+this.DistrictId)
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