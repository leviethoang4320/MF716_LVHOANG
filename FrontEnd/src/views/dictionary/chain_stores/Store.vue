<template>
    <div class="content-body">
        <div class="header-content">
          <div class="cnt-item" @click="dlg_openAdd()">
            <div class="ctn-item-icon icon-add mg-left-10px"></div>
            <div class="ctn-item-text mg-left-10px" >Thêm mới</div>
          </div>
          <div class="cnt-item">
            <div class="ctn-item-icon icon-copy mg-left-10px"></div>
            <div class="ctn-item-text mg-left-10px">Nhân bản</div>
          </div>
          <div class="cnt-item" @click="dlg_openEdit1()">
            <div class="ctn-item-icon icon-edit mg-left-10px"></div>
            <div class="ctn-item-text mg-left-10px">Sửa</div>
          </div>
          <div class="cnt-item" @click="dlg_openDel()">
            <div class="ctn-item-icon icon-del mg-left-10px"></div>
            <div class="ctn-item-text mg-left-10px">Xóa</div>
          </div>
          <div class="cnt-item" @click="load()">
            <div class="ctn-item-icon icon-load mg-left-10px"></div>
            <div class="ctn-item-text mg-left-10px">Nạp</div>
          </div>
          
        </div>
        
        <div class="grid ">

            <table  class="table" cellspacing="0" cellpadding="0" border="0"  >

                <thead class="table-head">
                    <tr class="table-row head first">
                        <th colspan="1" rowspan="1" width= "10%" >
                            Mã cửa hàng
                        </th>
                        <th colspan="1" rowspan="1" width= "25%" >
                            Tên cửa hàng
                        </th>
                        <th colspan="1" rowspan="1"  width= "35%">
                            Địa chỉ
                        </th>
                        <th colspan="1" rowspan="1"  width= "15%">
                            Số điện thoại
                        </th>
                        <th colspan="1" rowspan="1"  width= "15%">
                            Trạng thái hoạt động
                        </th>
                        
                    </tr>
                    <tr class="table-row head filter">
                        <th colspan="1" rowspan="1" v-for="(item,index) in store" :key="index" >
                            <table cellspacing="1px" cellpadding="1px" border="0" v-if="item.key!='Status'">
                                <tr  >
                                    <td style="width: 40px; text-align: center;" >*</td>
                                    <td></td>
                                </tr>
                                
                            </table>
                            <select v-else name="" id="" style="border:none;">
                                <option value="">Đang hoạt động</option>
                                <option value="">Không hoạt động</option>
                            </select>
                        </th>
                        
                        
                    </tr>
                    
                </thead>
                <tbody>
                    <tr name="tr" class="table-row table-body"  v-for="(data,index) in resData" :key="index" :id="data.StoreId" @click="onFocus(data.StoreId)" @dblclick="dlg_openEdit2(data.StoreId)" >
                        <td rowspan="1" colspan="1" v-for="(item,index) in store" :key="index"  >
                            <div class="cell" >
                                {{data[item.key]}}
                            </div>
                        </td>
                        
                    </tr>
                </tbody>

            </table>



        </div> 

        <div class="paging-bar">
            <div class="paging-option">
                <div class="btn-select-page  ">
                    <div class="m-btn-first-page"></div>
                </div>
                <div class="btn-select-page ">
                    <div class="m-btn-prev-page"></div>
                </div>
                <div>Trang</div>
                <div class="page-now " style="border: 1px solid rgb(133, 132, 132); height:20px; width:40px; padding-left:5px">1</div>
                <div >trên 1</div>
                <div class="btn-select-page ">
                    <div class="m-btn-next-page"></div>
                </div>
                <div class="btn-select-page ">
                    <div class="m-btn-last-page"></div>
                </div>
                <div class="btn-select-page ">
                    <div class="reload"></div>
                </div>
                <div>
                    <select name="" id="" style="height: 25px;">
                        <option value="">20</option>
                    </select>
                </div>
            </div>
            <div class="paging-info">
                
                <div>Hiển thị 1 - 20 trên 20 kết quả</div>
                
            </div>
            
        </div>
        
        
         <DialogDel  v-if="Delete.Confirm" @closeDel="del()" :Delete = "Delete"  /> 
         
        <div data-app>
         <DialogStore v-if="info.dialogOpen"  @close="close()" :info = "info" /> 
         </div>
    </div> 
</template>

<script>
import DialogStore from './DialogStore'
import DialogDel from './DialogDel'
import axios from 'axios'
export default {
    components:{
        DialogStore,
        DialogDel
    },
    data() {
        return {
            resData:Array,
            store:[
                {
                    key: "StoreCode" ,
                    title : "Mã cửa hàng"
                },
                {
                    key: "StoreName",
                    title : "Tên cửa hàng"
                },
                {
                    key: "Address",
                    title : "Địa chỉ"
                },
                {
                    key: "PhoneNumber",
                    title : "Số điện thoại"
                },
                {
                    key: "Status",
                    title : "Trạng thái hoạt động"
                },
            ],
            info:{
            StoreId: null,
            dialogOpen: false,
            status: String
            },
            tempId:"",
            Delete:{
                Confirm: false,
                StoreId: null,
            }
        }
    },
     mounted() {
        this.load()
    },
     methods: {
    
         load(){
             axios
            .get('https://localhost:44384/api/Stores')
            .then(response => {
                this.resData = response.data;
                
                
            })
            .catch(error => console.log(error));
        },
        onFocus(id){
            this.info.StoreId = id;

           if(this.tempId!=null&&this.tempId!=""){
              
            document.getElementById(this.tempId).classList.remove("selected");
           }
            document.getElementById(id).classList.add("selected");
            

            this.tempId = id;
            console.log(this.tempId)
            
            
        },
        close(){
            this.info.dialogOpen = false;
            this.load();
        },
        dlg_openAdd(){
            this.info.dialogOpen = !this.info.dialogOpen;
            this.info.status = "Thêm mới cửa hàng"
        },
        dlg_openEdit1(){
            if(this.info.StoreId){
                this.info.dialogOpen = !this.info.dialogOpen;
                this.info.status = "Sửa thông tin cửa hàng"
            }
        },
        dlg_openEdit2(StoreId){
            this.onFocus(StoreId)
            this.info.dialogOpen = !this.info.dialogOpen;
            this.info.status = "Sửa thông tin cửa hàng"
        },
        dlg_openDel(){
            if(this.info.StoreId){
                this.Delete.Confirm = true;
                this.Delete.StoreId = this.info.StoreId;
            }
        },
        del(){
            this.load();
            this.Delete.Confirm = !this.Delete.Confirm;
        }
        
     },

 }
 </script>

 <style scoped >

.content-body {
    background-color: #ffffff;
    height: calc(100% - 10px);
}

  .header-content{
    background-color: #2b3173;
  }
  .ctn-item-text{
    color: white ;

  }
  .cnt-item{
    display: flex;
    border-right: 1px solid #1e235a;
    height: 100%;
    align-items: center;
    padding-right: 5px;
    cursor: pointer;
  }

</style>
