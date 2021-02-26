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
                        <th colspan="1" rowspan="1" width="10%" >
                            Mã cửa hàng
                        </th>
                        <th colspan="1" rowspan="1" width="25%" >
                            Tên cửa hàng
                        </th>
                        <th colspan="1" rowspan="1"  width="35%">
                            Địa chỉ
                        </th>
                        <th colspan="1" rowspan="1"  width="15%">
                            Số điện thoại
                        </th>
                        <th colspan="1" rowspan="1"  width="15%">
                            Trạng thái hoạt động
                        </th>
                        
                    </tr>
                    <tr class="table-row head filter">
                        <th colspan="1" rowspan="1" >
                            <table cellspacing="1px" cellpadding="1px" border="0" >
                                <tr  >
                                    <td style="width: 40px; text-align: center;" >*</td>
                                    <td><input @change="getFilter()" type="text" v-model="filter.code"></td>
                                </tr>                             
                            </table>
                        </th>
                        <th colspan="1" rowspan="1" > 
                            <table cellspacing="1px" cellpadding="1px" border="0" >
                                <tr  >
                                    <td style="width: 40px; text-align: center;" >*</td>
                                    <td><input @change="getFilter()" type="text" v-model="filter.name"></td>
                                </tr>                               
                            </table>
                        </th>
                        <th colspan="1" rowspan="1" > 
                            <table cellspacing="1px" cellpadding="1px" border="0" >
                                <tr  >
                                    <td style="width: 40px; text-align: center;" >*</td>
                                    <td><input @change="getFilter()" type="text" v-model="filter.address"></td>
                                </tr>                                
                            </table>
                        </th>
                        <th colspan="1" rowspan="1" > 
                            <table cellspacing="1px" cellpadding="1px" border="0" >
                                <tr  >
                                    <td style="width: 40px; text-align: center;" >*</td>
                                    <td><input @change="getFilter()" type="text" v-model="filter.phone"></td>
                                </tr>                                
                            </table>
                        </th>
                        <th colspan="1" rowspan="1" > 
                            <table cellspacing="1px" cellpadding="1px" border="0" >
                                <tr  >
                                    <td>
                                   <select @change="getFilter()" name="" id="" style="border:none;" v-model="filter.status">
                                        <option value="Đang hoạt động">Đang hoạt động</option>
                                        <option value="Dừng hoạt động">Dừng hoạt động</option>
                                   </select>
                                   </td>                                    
                                </tr>                                
                            </table>                            
                        </th>                                                
                    </tr>                   
                </thead>
                <tbody>
                    <tr name="tr" class="table-row table-body"  v-for="(data,index) in resData" :key="index" :id="data.StoreId" @click="onFocus(data)" @dblclick="dlg_openEdit2(data)" >
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
                <div class="page-now " style="border: 1px solid rgb(133, 132, 132); height:20px; width:40px; padding-left:5px">{{page}}</div>
                <div ></div>
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
                    <select name="" v-model="pageSize" @change="load()" style="height: 25px;">
                        <option value="10" selected>10</option>
                        <option value="20">20</option>
                        <option value="30">30</option>
                        
                    </select>
                </div>
            </div>
            <div class="paging-info">
                
                <div>Hiển thị 1 - 20 trên 20 kết quả</div>                
            </div>           
        </div>  

        <DialogDelete  v-if="openDelete.deleteOpen" @closeDel="del()" :focusData="focusData"  />         
        
        <DialogStore v-if="openDialog.dialogOpen" @error="error" @success="success()"  @close="close()" :openDialog="openDialog" :focusData="focusData" /> 
        
        <Success v-if="success_"/>
        <Error v-if="error_" :msg_error="msg_error"/>
    </div> 
</template>

<script>
import DialogStore from './DialogStore'
import DialogDelete from '../common/DialogDelete'

import axios from 'axios'
import Success from '../common/Success.vue'
import Error from '../common/Error.vue'
export default {
    components:{
        DialogStore,
        DialogDelete,
        Success,
        Error
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
            openDialog:{                   
                dialogOpen: false,
                status: String
            },
            tempId:"",
            openDelete:{
                deleteOpen: false,
            },
            filter:{
                code: "",
                name: "",
                phone: "",
                address: "",
                status: "",

            },
            filter_:{
                code: "",
                name: "",
                phone: "",
                address: "",
                status: "",

            },
            focusData:{
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
            success_: false,
            error_:false,
            msg_error: "",
            page: 1,
            pageSize: 10
        }
    },
     created() {
        
        this.load();
    },
     methods: {
        //tải xuống dữ liệu
        load(){
            
             axios
            .get('https://localhost:44384/api/Stores/paginate',{params: {page: this.page, pageSize: this.pageSize}})
            .then(response => {
                this.resData = response.data;               
            })
            .catch(error => console.log(error));
        },
        //gán đối tượng đang trở đến vào focusData
        onFocus(data){
            for( var _item in data){
                      
                var item = _item.toString();
                this.focusData[item] = data[item];
            }
            if(this.tempId!=null&&this.tempId!=""){
                
                document.getElementById(this.tempId).classList.remove("selected");
            }
            document.getElementById(this.focusData.StoreId).classList.add("selected");
            this.tempId = this.focusData.StoreId;           
        },
        //đóng dialog
        close(){
            this.openDialog.dialogOpen = false;
            
        },
        //mở dialog thêm cửa hàng
        dlg_openAdd(){
            this.openDialog.dialogOpen = !this.openDialog.dialogOpen;
            this.openDialog.status = "Thêm mới cửa hàng"
        },
        //mở dialog sửa bằng nhấn vào nút sửa
        dlg_openEdit1(){
            if(this.focusData.StoreId){
                this.openDialog.dialogOpen = !this.openDialog.dialogOpen;
                this.openDialog.status = "Sửa thông tin cửa hàng"
            }
        },
        //mở dialog sửa bằng nhấn đúp dòng
        dlg_openEdit2(data){
            this.onFocus(data);
            this.openDialog.dialogOpen = !this.openDialog.dialogOpen;
            this.openDialog.status = "Sửa thông tin cửa hàng"
        },
        //mở dialog xóa
        dlg_openDel(){
            if(this.focusData.StoreId){
                if(this.tempId){
                document.getElementById(this.tempId).classList.remove("selected");
                this.tempId = null;
                }
                this.openDelete.deleteOpen = true;               
            }
        },
        //đóng cửa sổ xóa
        del(){
            this.openDelete.deleteOpen = !this.openDelete.deleteOpen;           
            this.load();  
        },
        //lọc dữ liệu theo điều kiện từng cột
        getFilter(){            
            
            
            axios.get('https://localhost:44384/api/Stores/filter', {params:
               
            { code: this.filter.code , name: this.filter.name , address:this.filter.address , phone: this.filter.phone, status: this.filter.status }}
            )
            .then(response => {
                this.resData = response.data;                                
            })
            .catch(error => console.log(error));
        },
        //mở dialog thông báo thành công
        success(){
            this.openDialog.dialogOpen = false;
            this.load();
            this.success_ = true;
            setTimeout(()=>{
                this.success_ = false;
            },3000);
        },
        //mở dialog báo lỗi
        error(msg){
            console.log(msg)
            this.msg_error = "";
            msg.forEach(element => {
                this.msg_error += element;
            });
            
                
                setTimeout(()=>{
                    this.error_ = true;
                },10);

                this.error_ = false;
            
            
            setTimeout(()=>{
                this.error_ = false;
            },10000);
        }
        
     },

 }
 </script>

<style scoped >

.content-body {
    background-color: #ffffff;
    height: calc(100% - 10px);
    margin-right: 15px;
}

.header-content{
    background-color: #00577b;
}
.ctn-item-text{
    color: white ;

}
.cnt-item{
    display: flex;
    border-right: 1px solid #003f5a;
    height: 100%;
    align-items: center;
    padding-right: 5px;
    cursor: pointer;
}
.cnt-item:hover{
    background-color: #0088c1;
}
tr.table-row.head.filter input {
    border: none !important;
}
tr.table-row.head.filter select {
    border: none !important;
    border-radius: 0px !important ;
    height: 100%;

}
tr.table-row.head.filter td {
    padding: 0 !important;
}
tr.table-row.head.filter input,select {
    height: 20px;
}

</style>
