/* Create a new Vue instance to manage the note taking app */
new Vue({
  // Mount the Vue instance on the element with id="app"
  el: '#app',

  // Define reactive data properties for the app
  data: {
    newNote: '',       // Holds the text input for a new note
    notes: [],         // Array to store note objects (each note: id, text, date)
    editingNoteId: null,  // ID of the note currently being edited; null when not editing
    editedText: '',    // Temporary storage for edited note text
  },

  // Methods define functions that modify the data and handle user interactions
  methods: {
    // Add a new note to the list
    addNote() {
      // Only add the note if the input is not empty (after trimming whitespace)
      if (this.newNote.trim() !== '') {
        // Create a new note object with a unique id, the note text, and the current date/time
        const note = {
          id: Date.now(),  // Use current timestamp as a unique identifier
          text: this.newNote,
          date: new Date().toLocaleString(), // Format the current date and time
        };
        // Add the new note to the notes array
        this.notes.push(note);
        // Clear the input field after adding the note
        this.newNote = '';
      }
    },

    // Delete a note by filtering it out of the notes array using its id
    deleteNote(noteId) {
      this.notes = this.notes.filter(note => note.id !== noteId);
    },

    // Enter edit mode for a specific note
    editNote(noteId) {
      // Set the editingNoteId to the id of the note being edited
      this.editingNoteId = noteId;
      // Find the note to prefill the editing input field with its current text
      const note = this.notes.find(note => note.id === noteId);
      this.editedText = note.text;
    },

    // Save the changes made to a note and exit edit mode
    saveNote(noteId) {
      // Locate the note being edited
      const note = this.notes.find(note => note.id === noteId);
      // Update the note only if the edited text is not empty
      if (note && this.editedText.trim() !== '') {
        note.text = this.editedText;
        // Optionally update the note's date to reflect the modification time
        note.date = new Date().toLocaleString();
      }
      // Exit editing mode by resetting the editingNoteId and editedText
      this.editingNoteId = null;
      this.editedText = '';
    },

    // Cancel editing and revert back to display mode without saving changes
    cancelEdit() {
      this.editingNoteId = null;
      this.editedText = '';
    },
  },
});
