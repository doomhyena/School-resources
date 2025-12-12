/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mp3player1118regib;

import java.io.File;
import java.net.URL;
import java.util.ArrayList;
import java.util.ResourceBundle;
import java.util.Timer;
import java.util.TimerTask;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ProgressBar;
import javafx.scene.control.Slider;
import javafx.scene.layout.Pane;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;

/**
 *
 * @author tanár
 */
public class FXMLDocumentController implements Initializable {
    
    @FXML
    private Pane pane;
    
    @FXML
    private Label labelSong;
    
    @FXML
    private Button btnPlay,btnPause,btnReplay,btnPrev,btnNext;
    
    @FXML
    private Slider sliderVolume;
    
    @FXML
    private ProgressBar progressbarSong;
    
    private Media media;
    private MediaPlayer mediaPlayer;
    
    private File directory;
    private File[] files;
    private ArrayList<File> songs;
    private int songNumbers;
    
    private Timer timer;
    private TimerTask task;
    private boolean isRunning;
    
    
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
        songs = new ArrayList<File>();
        directory = new File("music");
        files = directory.listFiles();
        if (files != null){
            for (File n : files){
                songs.add(n);
                System.out.println(n);
            }
        }
        media = new Media(songs.get(songNumbers).toURI().toString());
        mediaPlayer = new MediaPlayer(media);
        
        sliderVolume.valueProperty().addListener(new ChangeListener<Number>() {

            @Override
            public void changed(ObservableValue<? extends Number> ov, Number t, Number t1) {
                mediaPlayer.setVolume(sliderVolume.getValue()*0.01);
            }
        });
    }  
    
    public void playMedia(){
        mediaPlayer.play();
    }
    
    public void pauseMedia(){
        
    }
    
    public void replayMedia(){
        
    }
    
    public void prevMedia(){
        
    }
    
    public void nextMedia(){
        
    }
    
    
}
