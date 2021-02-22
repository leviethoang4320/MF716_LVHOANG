<template>
  <div id="app">
    <v-main>
      <Navbar />
      <Header />
      <Content />
    </v-main>
  </div>
</template>

<script>
import Navbar from "@/components/layout/Navbar";
import Header from "@/components/layout/Header";
import Content from "@/components/layout/Content";

export default {
  name: "App",

  components: {
    Navbar,
    Header,
    Content,
  },

  data: () => ({
    //
  }),
};
</script>
<style >
@import "./styles/index.css";


</style>
