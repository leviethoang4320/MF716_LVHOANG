<template>
    <div class="dialog">
        <div class="dialog-bg"></div>
        <div class="dialog-confirm"  >
            <div class="dialog-title">
                <span class="headline">Xóa dữ liệu</span>
                <span class="icon-close"  @click="dlg_close()"></span>
            </div>
            <div class="dialog-content">Bạn có chắc muốn xóa <span style="font-weight: bold;">{{this.focusData.StoreName}}</span> khỏi danh sách ?</div>
            <div class="dialog-footer">
                
                <button @click="del()"  class="m-btn m-btn-default m-btn-del m-flex" ><div class="icon-del"></div><span  class="btn-text del">Xóa</span></button>
                <button @click="dlg_close()" class="m-btn m-btn-default" ><span></span><span  class="btn-text cancel">Hủy bỏ</span></button>
            </div>

        </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
    props:{
        focusData: Object,
    },
    data:() => {
        return {
            //name: String
        }
    },
    methods: {
        del(){
            
           axios.delete('https://localhost:44384/api/Stores/'+this.focusData.StoreId)
            .then(response => {

                    console.log(response);
                    alert("Đã Xóa Thành Công!");
                    this.dlg_close();
            })
            .catch(error => console.log(error))
        },
        dlg_close(){
            
            this.$emit('closeDel');
        }
    },
}
</script>

<style scoped>

.dialog-confirm{
    height: 200px;
    width: 400px;
    background-color: white;
    z-index: 1000;
    position: absolute;
    left: calc(50% - 200px);
    top: calc(50% - 100px);
}
.dialog-footer {
    display: flex;
    width: 100%;
    height: 50px;
    background-color: white;
    border-radius: 0 0 5px 5px;
    border-top: 1px solid #bbbbbb;
    align-items: center;
    justify-content: flex-end;
    padding: 12px 24px;
    box-sizing: border-box;
    position: absolute;
    bottom: 0;
}
.dialog-content {
    font-size: 17px;
}
.dialog-content {
   
    margin-left: 35px;
    margin-right: 10px;
}
.dialog-title {
    font-size: 20px;
    margin-left: 0px;
    background-color: #e9ebee;
    margin-top: 0;
    height: 50px;
}
button.m-btn.m-btn-default.m-btn-del {
    background-color: #e14c4c;
    color: #e9ebee;
    align-items: center;
}
.btn-text.del{
    margin-left: 10px;
}


</style>