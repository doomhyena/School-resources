// Jegyzetes App vue.js elemekkel

new Vue ({
    el: '#app',
    data: {
        newNote: '', 
        notes: [],
        editingIndex: null,
        editingText: '',
    },
    methods: {
        addNote() {
            const text = this.newNote.trim();
            if (text) {
                this.notes.push({
                    id: Date.now() + Math.random().toString(36).substr(2, 9),
                    text
                })
                this.newNote = '';
            }
        },
        deleteNote(index) {
            this.notes.splice(index, 1);
            if (this.editingIndex === index) {
                this.editingIndex = null;
                this.editingText = '';
            }
        },
        editNote(index) {
            this.editingIndex = index;
            this.editingText = this.notes[index].text;
        },
        saveEdit(index) {
            const text = this.editingText.trim();
            if (text) {
                this.notes[index].text = text;
                this.editingIndex = null;
                this.editingText = '';
            }
        },
        cancelEdit() {
            this.editingIndex = null;
            this.editingText = '';
        }
    }
})