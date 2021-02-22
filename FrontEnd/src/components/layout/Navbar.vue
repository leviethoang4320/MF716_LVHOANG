<template>
    <div class="navbar">
        <div class="logo-site">
            <div class="logo-box">
                <div class="eshop-logo"></div>
            </div>
        </div>
        <div class="navbar-content">
            <a class="nav-item">
                <div class="nav-item-icon nav-item-dashboard"></div>
                <div class="nav-item-text">Tổng quan</div>
            </a>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-report"></div>
                <div class="nav-item-text">Báo cáo</div>
            </a>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-order"></div>
                <div class="nav-item-text">Đơn hàng</div>
            </a>
            <a class="nav-item" >
                <div class="nav-item-icon nav-item-buy"></div>
                <div class="nav-item-text">Mua hàng</div>
            </a>
            <a class="nav-item" >
                <div class="nav-item-icon nav-item-sale"></div>
                <div class="nav-item-text">Khuyến mại</div>
            </a>
            <router-link class="nav-item" to="/dictionary/store" style="text-decoration:none">
                <div class="nav-item-icon nav-item-store"></div>
                <div class="nav-item-text">Quản lý cửa hàng</div>
            </router-link>
            
            <a class="nav-item">
                <div class="nav-item-icon nav-item-goods"></div>
                <div class="nav-item-text">Hàng hóa</div>
            </a>

        </div>
    </div>
</template>
<script>
export default {
  name: 'MenuBarLinks',
  data () {
    return {

      
    };
  }
};
</script>
