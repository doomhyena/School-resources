/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mp3_1118regia;

import java.io.File;
import java.net.URL;
import java.util.ArrayList;
import java.util.ResourceBundle;
import java.util.Timer;
import java.util.TimerTask;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.concurrent.Task;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ProgressBar;
import javafx.scene.control.Slider;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.Pane;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;
import javafx.util.Duration;

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
    private ProgressBar progressbarSong;
    
    @FXML
    private Slider sliderVolume,sliderSong;
    
    private Media media;
    private MediaPlayer mediaPlayer;
    
    private File library;
    private File[] files;
    private ArrayList<File> songs;
    private int songNumber;
    private Timer timer;
    private TimerTask task;
    private boolean isRunning;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
        songs = new ArrayList<File>();
        library = new File("music");
        files = library.listFiles();
        if (files != null){
            for(File n : files){
                songs.add(n);
                System.out.println(n);
            }
        }
        
        media = new Media(songs.get(songNumber).toURI().toString());
        mediaPlayer = new MediaPlayer(media);
        labelSong.setText(songs.get(songNumber).getName());
        sliderVolume.valueProperty().addListener(new ChangeListener<Number>() {

            @Override
            public void changed(ObservableValue<? extends Number> ov, Number t, Number t1) {
                mediaPlayer.setVolume(sliderVolume.getValue()*0.01);
            }
        });
        
        mediaPlayer.currentTimeProperty().addListener(new ChangeListener<Duration>() {

            @Override
            public void changed(ObservableValue<? extends javafx.util.Duration> observable, javafx.util.Duration oldValue, javafx.util.Duration newValue) {
                sliderSong.setValue(newValue.toSeconds());
            }
        });
        
        sliderSong.setOnMousePressed(new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent t) {
                mediaPlayer.seek(javafx.util.Duration.seconds(sliderSong.getValue()));
            }
        });
        
        sliderSong.setOnMouseDragged(new EventHandler<MouseEvent>() {
                @Override
                public void handle(MouseEvent event) {
                    mediaPlayer.seek(javafx.util.Duration.seconds(sliderSong.getValue()));
                }
            });
            
            mediaPlayer.setOnReady(new Runnable() {
                @Override
                public void run() {
                    javafx.util.Duration total = media.getDuration();
                    sliderSong.setMax(total.toSeconds());
                }
            });
    }
    
    public void playMedia(){
        startTimer();
        mediaPlayer.play();
        mediaPlayer.setVolume(sliderVolume.getValue()*0.01);
    }
    
    public void pauseMedia(){
        cancelTimer();
        mediaPlayer.pause();
    }
    
    public void replayMedia(){
        mediaPlayer.seek(Duration.ZERO);
        //mediaPlayer.stop();
    }
    
    public void prevMedia(){
        if (songNumber>0){
            songNumber--;
            mediaPlayer.stop();
            
            media = new Media(songs.get(songNumber).toURI().toString());
            mediaPlayer = new MediaPlayer(media);
            mediaPlayer.play();
            labelSong.setText(songs.get(songNumber).getName());
        }
        else{
            songNumber = songs.size()-1;
            mediaPlayer.stop();
            
            media = new Media(songs.get(songNumber).toURI().toString());
            mediaPlayer = new MediaPlayer(media);
            mediaPlayer.play();
            labelSong.setText(songs.get(songNumber).getName());
        }
    }
    
    public void nextMedia(){
        if (songNumber < songs.size()-1){
            songNumber++;
            mediaPlayer.stop();
            //if (isRunning) cancelTimer();
            media = new Media(songs.get(songNumber).toURI().toString());
            mediaPlayer = new MediaPlayer(media);
            mediaPlayer.play();
            labelSong.setText(songs.get(songNumber).getName());
        }
        else{
            songNumber = 0;
            mediaPlayer.stop();
            
            media = new Media(songs.get(songNumber).toURI().toString());
            mediaPlayer = new MediaPlayer(media);
            mediaPlayer.play();
            labelSong.setText(songs.get(songNumber).getName());
        }
    }
    
    public void startTimer(){
        timer = new Timer();
        task = new TimerTask() {

            @Override
            public void run() {
              isRunning = true;
              double current = mediaPlayer.getCurrentTime().toSeconds();
              final double end = media.getDuration().toSeconds();
                System.out.println(current/end);
                progressbarSong.setProgress(current/end);
                
                if (current/end == 1){
                    cancelTimer();
                }
            }
        };
        timer.scheduleAtFixedRate(task, 0, 50);
    }
    
    public void cancelTimer(){
        isRunning = false;
        timer.cancel();
    }
}
