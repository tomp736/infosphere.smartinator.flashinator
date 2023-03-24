// main.js
const app = new Vue({
    el: '#app',
    data: {
      card: null,
      showBack: false
    },
    mounted() {
      this.getFlashcard();
    },
    methods: {
      getFlashcard() {
        fetch('http://localhost:5000/flashinator/random')
          .then(response => response.json())
          .then(data => this.card = data)
          .catch(error => console.error(error));
      },
      flipCard() {
        this.showBack = !this.showBack;
      }
    }
  });
  