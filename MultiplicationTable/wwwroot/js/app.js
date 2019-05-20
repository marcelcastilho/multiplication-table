Vue.component('matrix', {
    data: function () {
        return {
            rows: null
        };
    },
    methods: {
        render: function () {
            axios
                .get('/api/multiplication-table?matrixSize=' + this.matrix_size + '&matrixBase=' + this.matrix_base)
                .then(response => this.rows = response.data);
        }
    },
    props: ['matrix_size', 'matrix_base'],
    template: '<table><matrix-row v-for="row in rows" v-bind:row="row"></matrix-row></table> ',
    watch: {
        'matrix_size': function () {
            this.render();
        },
        'matrix_base': function () {
            this.render();
        }
    },
    mounted() {
        this.render();
    }
});

Vue.component('matrix-row', {
    props: ['row'],
    template: '<tr><matrix-cell v-for="cell in row" v-bind:cell="cell"></matrix-cell></tr>'
});

Vue.component('matrix-cell', {
    props: ['cell'],
    template: '<td>{{ cell }}</td>'
});

var app = new Vue({
    el: '#app',
    data: {
        matrix_size: '10',
        matrix_base: 10
    }
});
