package nl.videodock.mediasession;

public interface OnMediaSessionEventListener {
    void onPlay();
    void onPause();
    void onPlayPause();
    void onStop();
    void onNext();
    void onPrev();
    void onFastForward();
    void onRewind();
    void onVolumeUp();
    void onVolumeDown();
}