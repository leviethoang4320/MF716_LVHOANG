<template>
    <div class="dialog">
        <div class="dialog-bg"></div>
        <div class="dialog-confirm"  >
            <div class="dialog-title">Xóa dữ liệu</div>
            <div class="dialog-content">Bạn có chắc muốn xóa <span style="font-weight: bold;">{{this.Delete.StoreName}}</span> khỏi danh sách cửa hàng?</div>
            <div class="dialog-footer">
                
                <button @click="del()"  class="m-btn m-btn-default m-btn-del" ><span></span><span  class="btn-text">Xóa</span></button>
                <button @click="dlg_close()" class="m-btn m-btn-default" ><span></span><span  class="btn-text">Hủy bỏ</span></button>
            </div>

        </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
    props:{
        Delete: Object,
    },
    data:() => {
        return {
            //name: String
        }
    },
    methods: {
        del(){
            
           axios.delete('https://localhost:44384/api/Stores/'+this.Delete.StoreId)
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
    border-top: 1px solid #e9ebee;
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
}

</style>